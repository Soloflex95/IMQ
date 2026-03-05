namespace IMQ.Core.Entities;

/// <summary>
/// Standardized education evidence for a worker.
/// </summary>
public class EducationRecord
{
    public string Degree { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public string Institution { get; set; } = string.Empty;
    public int GraduationYear { get; set; }
    public string VerificationStatus { get; set; } = "Verified";
    public string? EvidenceSource { get; set; }
}
