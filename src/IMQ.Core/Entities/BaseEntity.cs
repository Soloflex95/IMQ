namespace IMQ.Core.Entities;

/// <summary>
/// Base entity class with audit fields for 21 CFR Part 11 compliance
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// Soft delete flag - never hard delete for audit trail compliance
    /// </summary>
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    /// <summary>
    /// Row version for optimistic concurrency control
    /// </summary>
    public byte[]? RowVersion { get; set; }
    
    /// <summary>
    /// Tenant ID for multi-tenancy support
    /// </summary>
    public Guid TenantId { get; set; }
}
