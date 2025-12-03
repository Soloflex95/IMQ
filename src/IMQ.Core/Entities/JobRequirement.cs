namespace IMQ.Core.Entities;

/// <summary>
/// Required skill/competency for a job
/// </summary>
public class JobRequirement : BaseEntity
{
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    
    /// <summary>
    /// Whether this requirement is mandatory or optional
    /// </summary>
    public bool IsRequired { get; set; } = true;
    
    /// <summary>
    /// Minimum proficiency level (1-5 scale)
    /// </summary>
    public int? MinimumLevel { get; set; }
    
    /// <summary>
    /// Minimum years of experience for this specific skill
    /// </summary>
    public int? MinimumYears { get; set; }
    
    /// <summary>
    /// Notes for assessment
    /// </summary>
    public string? Notes { get; set; }
}
