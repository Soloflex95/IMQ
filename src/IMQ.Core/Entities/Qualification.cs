using IMQ.Core.Enums;

namespace IMQ.Core.Entities;

/// <summary>
/// Worker's qualification/competency evidence
/// </summary>
public class Qualification : BaseEntity
{
    public Guid WorkerId { get; set; }
    public Worker Worker { get; set; } = null!;
    
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    
    /// <summary>
    /// Years of experience with this skill
    /// </summary>
    public decimal YearsExperience { get; set; }
    
    /// <summary>
    /// Self-assessed proficiency level (1-5 scale)
    /// </summary>
    public int? ProficiencyLevel { get; set; }
    
    /// <summary>
    /// Certification name (if applicable)
    /// </summary>
    public string? CertificationName { get; set; }
    
    /// <summary>
    /// Certification issue date
    /// </summary>
    public DateTime? CertificationIssueDate { get; set; }
    
    /// <summary>
    /// Certification expiry date (for assessment logic)
    /// </summary>
    public DateTime? CertificationExpiryDate { get; set; }
    
    /// <summary>
    /// Training records from LMS integration
    /// </summary>
    public string? TrainingRecords { get; set; }
    
    /// <summary>
    /// Uploaded CV/resume text (parsed by AI/NLP)
    /// </summary>
    public string? CvText { get; set; }
    
    /// <summary>
    /// Supporting documentation URLs/paths
    /// </summary>
    public string? SupportingDocuments { get; set; }
    
    /// <summary>
    /// Assessment status (color-coded)
    /// </summary>
    public AssessmentStatus Status { get; set; } = AssessmentStatus.Draft;
    
    /// <summary>
    /// Assessment results from Assessment Engine
    /// </summary>
    public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
}
