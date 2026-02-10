using IMQ.Core.Enums;

namespace IMQ.Core.Entities;

/// <summary>
/// Canonical, normative role requirement for the Master Requirements List (MRL)
/// </summary>
public class QualificationRequirement : BaseEntity
{
    public QualificationRequirement()
    {
        ApprovedAt = DateTime.UtcNow;
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public RequirementType RequirementType { get; set; }
    public RequirementLevel RequirementLevel { get; set; }
    public string Source { get; set; } = string.Empty;
    public RequirementApprovalStatus RequirementApprovalStatus { get; set; }
    public string ApprovedBy { get; set; } = string.Empty;
    public DateTime ApprovedAt { get; set; }
    public DateTime? LastReviewed { get; set; }
    public string? ReviewedBy { get; set; }
    public string Version { get; set; } = string.Empty;
    public List<string>? Tags { get; set; }
}