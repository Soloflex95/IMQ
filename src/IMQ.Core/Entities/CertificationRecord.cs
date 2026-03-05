namespace IMQ.Core.Entities;

/// <summary>
/// Standardized certification evidence for a worker.
/// </summary>
public class CertificationRecord
{
    public string CertificationName { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public DateOnly DateAcquired { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? EvidenceSource { get; set; }
}
