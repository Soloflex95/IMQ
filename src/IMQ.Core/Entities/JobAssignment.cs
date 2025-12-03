namespace IMQ.Core.Entities;

/// <summary>
/// Worker assignment to a job (many-to-many)
/// </summary>
public class JobAssignment : BaseEntity
{
    public Guid WorkerId { get; set; }
    public Worker Worker { get; set; } = null!;
    
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    
    /// <summary>
    /// Assignment start date
    /// </summary>
    public DateTime AssignedDate { get; set; }
    
    /// <summary>
    /// Assignment end date (if temporary)
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Whether this is the worker's primary job
    /// </summary>
    public bool IsPrimary { get; set; }
}
