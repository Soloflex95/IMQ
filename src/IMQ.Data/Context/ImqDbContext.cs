using Microsoft.EntityFrameworkCore;
using IMQ.Core.Entities;

namespace IMQ.Data.Context;

/// <summary>
/// IMQ Database Context with multi-tenancy and audit trail support
/// </summary>
public class ImqDbContext : DbContext
{
    private readonly Guid _currentTenantId;
    private readonly string _currentUserId;
    
    public ImqDbContext(DbContextOptions<ImqDbContext> options, Guid tenantId, string userId) 
        : base(options)
    {
        _currentTenantId = tenantId;
        _currentUserId = userId;
    }
    
    public DbSet<Worker> Workers => Set<Worker>();
    public DbSet<OrgUnit> OrgUnits => Set<OrgUnit>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobRequirement> JobRequirements => Set<JobRequirement>();
    public DbSet<Qualification> Qualifications => Set<Qualification>();
    public DbSet<JobAssignment> JobAssignments => Set<JobAssignment>();
    public DbSet<Assessment> Assessments => Set<Assessment>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply global query filter for multi-tenancy (all BaseEntity types)
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var tenantCheck = System.Linq.Expressions.Expression.Lambda(
                    System.Linq.Expressions.Expression.AndAlso(
                        System.Linq.Expressions.Expression.Equal(
                            System.Linq.Expressions.Expression.Property(parameter, nameof(BaseEntity.TenantId)),
                            System.Linq.Expressions.Expression.Constant(_currentTenantId)),
                        System.Linq.Expressions.Expression.Equal(
                            System.Linq.Expressions.Expression.Property(parameter, nameof(BaseEntity.IsDeleted)),
                            System.Linq.Expressions.Expression.Constant(false))),
                    parameter);
                
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(tenantCheck);
            }
        }
        
        // Configure concurrency tokens
        modelBuilder.Entity<Worker>().Property(w => w.RowVersion).IsRowVersion();
        modelBuilder.Entity<Job>().Property(j => j.RowVersion).IsRowVersion();
        modelBuilder.Entity<Qualification>().Property(q => q.RowVersion).IsRowVersion();
        modelBuilder.Entity<Assessment>().Property(a => a.RowVersion).IsRowVersion();
        
        // Configure indexes for performance
        modelBuilder.Entity<Worker>().HasIndex(w => w.Email);
        modelBuilder.Entity<Worker>().HasIndex(w => w.EmployeeId);
        modelBuilder.Entity<AuditLog>().HasIndex(a => new { a.EntityType, a.EntityId, a.Timestamp });
        modelBuilder.Entity<Assessment>().HasIndex(a => a.Status);
        
        // Configure relationships
        modelBuilder.Entity<Worker>()
            .HasOne(w => w.Manager)
            .WithMany()
            .HasForeignKey(w => w.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<OrgUnit>()
            .HasOne(o => o.Parent)
            .WithMany(o => o.Children)
            .HasForeignKey(o => o.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Auto-populate audit fields
        var entries = ChangeTracker.Entries<BaseEntity>();
        
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _currentUserId;
                    entry.Entity.TenantId = _currentTenantId;
                    entry.Entity.IsDeleted = false;
                    break;
                    
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = _currentUserId;
                    break;
                    
                case EntityState.Deleted:
                    // Soft delete instead of hard delete
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    entry.Entity.DeletedBy = _currentUserId;
                    break;
            }
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
}
