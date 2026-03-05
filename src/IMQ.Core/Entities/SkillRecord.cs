namespace IMQ.Core.Entities;

/// <summary>
/// Standardized skill evidence and required proficiency comparison.
/// </summary>
public class SkillRecord
{
    public string SkillName { get; set; } = string.Empty;
    public int WorkerLevel { get; set; }
    public int RequiredLevel { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? EvidenceSource { get; set; }
}
