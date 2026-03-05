namespace IMQ.Core.Entities;

/// <summary>
/// Standardized training completion evidence for a worker.
/// </summary>
public class TrainingRecord
{
    public string CourseName { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public DateOnly CompletionDate { get; set; }
    public int? RecertCycleMonths { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? EvidenceSource { get; set; }
}
