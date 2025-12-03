namespace IMQ.Core.Entities;

/// <summary>
/// Worker (user) who holds qualifications and is assigned to jobs
/// </summary>
public class Worker : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Employee ID from HRIS
    /// </summary>
    public string? EmployeeId { get; set; }
    
    /// <summary>
    /// Department/Org Unit assignment
    /// </summary>
    public Guid? OrgUnitId { get; set; }
    public OrgUnit? OrgUnit { get; set; }
    
    /// <summary>
    /// Manager assignment for approval workflows
    /// </summary>
    public Guid? ManagerId { get; set; }
    public Worker? Manager { get; set; }
    
    /// <summary>
    /// Qualifications held by this worker
    /// </summary>
    public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    
    /// <summary>
    /// Job assignments for this worker
    /// </summary>
    public ICollection<JobAssignment> JobAssignments { get; set; } = new List<JobAssignment>();
}
