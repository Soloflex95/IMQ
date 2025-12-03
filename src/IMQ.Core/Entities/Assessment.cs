using IMQ.Core.Enums;

namespace IMQ.Core.Entities;

/// <summary>
/// Assessment result for worker qualification against job requirements
/// Immutable for audit trail compliance
/// </summary>
public class Assessment : BaseEntity
{
    public Guid QualificationId { get; set; }
    public Qualification Qualification { get; set; } = null!;
    
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    
    /// <summary>
    /// Assessment outcome (green/yellow/red)
    /// </summary>
    public AssessmentStatus Status { get; set; }
    
    /// <summary>
    /// Match score (0-100%)
    /// </summary>
    public decimal MatchScore { get; set; }
    
    /// <summary>
    /// Assessment Engine output (explainable AI)
    /// </summary>
    public string? AssessmentRationale { get; set; }
    
    /// <summary>
    /// Identified gaps
    /// </summary>
    public string? Gaps { get; set; }
    
    /// <summary>
    /// Assessed by (system or user ID)
    /// </summary>
    public string AssessedBy { get; set; } = "System";
    
    public DateTime AssessedAt { get; set; }
    
    /// <summary>
    /// Manager approval fields (21 CFR Part 11 e-signature)
    /// </summary>
    public bool? ManagerApproved { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string? ApprovalReason { get; set; }
    
    /// <summary>
    /// Manager override justification (required for override)
    /// </summary>
    public string? OverrideJustification { get; set; }
    
    /// <summary>
    /// E-signature reason code
    /// </summary>
    public string? ReasonCode { get; set; }
    
    /// <summary>
    /// Published to Auditor Portal
    /// </summary>
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public string? PublishedBy { get; set; }
}
