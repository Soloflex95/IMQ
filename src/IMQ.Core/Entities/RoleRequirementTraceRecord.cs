using IMQ.Core.Enums;

namespace IMQ.Core.Entities;

/// <summary>
/// Deterministic requirement-to-evidence trace row used in qualification review screens.
/// </summary>
public class RoleRequirementTraceRecord
{
    public string RequirementName { get; set; } = string.Empty;
    public RequirementAssessmentType RequirementType { get; set; } = RequirementAssessmentType.Mandatory;
    public string Status { get; set; } = string.Empty;
    public bool IsMet { get; set; }
    public string MatchedEvidence { get; set; } = string.Empty;
}