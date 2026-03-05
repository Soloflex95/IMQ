namespace IMQ.Core.Entities;

/// <summary>
/// Structured qualification record for a worker.
/// </summary>
public class QualificationRecord
{
    public string WorkerId { get; set; } = string.Empty;
    public string WorkerName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string QualificationStatus { get; set; } = string.Empty;
    public IReadOnlyList<CertificationRecord> Certifications { get; set; } = Array.Empty<CertificationRecord>();
    public IReadOnlyList<TrainingRecord> TrainingRecords { get; set; } = Array.Empty<TrainingRecord>();
    public IReadOnlyList<SkillRecord> Skills { get; set; } = Array.Empty<SkillRecord>();
    public IReadOnlyList<EducationRecord> Education { get; set; } = Array.Empty<EducationRecord>();
    public IReadOnlyList<RoleRequirementTraceRecord> RoleRequirements { get; set; } = Array.Empty<RoleRequirementTraceRecord>();
}
