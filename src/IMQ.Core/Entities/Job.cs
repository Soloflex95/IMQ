namespace IMQ.Core.Entities;

/// <summary>
/// Job/Role definition template with required qualifications
/// </summary>
public class Job : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Code { get; set; }
    public string? Description { get; set; }
    
    /// <summary>
    /// Department/Org Unit this job belongs to
    /// </summary>
    public Guid? OrgUnitId { get; set; }
    public OrgUnit? OrgUnit { get; set; }
    
    /// <summary>
    /// Minimum years of experience required
    /// </summary>
    public int RequiredYearsExperience { get; set; }
    
    /// <summary>
    /// Job requirements (skills, training, certs)
    /// </summary>
    public ICollection<JobRequirement> Requirements { get; set; } = new List<JobRequirement>();
    
    /// <summary>
    /// Workers assigned to this job
    /// </summary>
    public ICollection<JobAssignment> Assignments { get; set; } = new List<JobAssignment>();
    
    /// <summary>
    /// Effective date for requirements versioning
    /// </summary>
    public DateTime? EffectiveDate { get; set; }
    
    /// <summary>
    /// Version number for requirements changes
    /// </summary>
    public int Version { get; set; } = 1;
}
