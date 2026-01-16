using IMQ.Core.Enums;

namespace IMQ.Core.Interfaces;

/// <summary>
/// Service for calculating compliance between worker qualifications and job requirements
/// </summary>
public interface IComplianceCalculationService
{
    /// <summary>
    /// Calculate compliance for a worker against a specific job's requirements
    /// </summary>
    Task<ComplianceResult> CalculateComplianceAsync(Guid workerId, Guid jobId, CancellationToken cancellationToken = default);
}

/// <summary>
/// Result of compliance calculation
/// </summary>
public class ComplianceResult
{
    public bool IsCompliant { get; set; }
    public ComplianceStatus Status { get; set; }
    public List<string> MissingRequirements { get; set; } = new();
    public List<string> ExpiredQualifications { get; set; } = new();
    public List<RequirementMatch> Requirements { get; set; } = new();
    public int QualifiedCount { get; set; }
    public int TotalRequirements { get; set; }
    public double CompliancePercentage => TotalRequirements > 0 ? (double)QualifiedCount / TotalRequirements * 100 : 0;
}

/// <summary>
/// Details of a specific requirement match
/// </summary>
public class RequirementMatch
{
    public string RequirementName { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public bool IsMet { get; set; }
    public string? Reason { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? DaysUntilExpiration { get; set; }
}
