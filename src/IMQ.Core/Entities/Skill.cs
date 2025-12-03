namespace IMQ.Core.Entities;

/// <summary>
/// Reusable skill/competency definition (e.g., "Aseptic Technique Level 2")
/// </summary>
public class Skill : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
    public string? Description { get; set; }
    
    /// <summary>
    /// Category for grouping skills (e.g., "Technical", "Safety", "Quality")
    /// </summary>
    public string? Category { get; set; }
    
    /// <summary>
    /// Whether this skill requires certification
    /// </summary>
    public bool RequiresCertification { get; set; }
    
    /// <summary>
    /// Job requirements that include this skill
    /// </summary>
    public ICollection<JobRequirement> JobRequirements { get; set; } = new List<JobRequirement>();
    
    /// <summary>
    /// Worker qualifications for this skill
    /// </summary>
    public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
}
