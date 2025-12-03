namespace IMQ.Core.Enums;

/// <summary>
/// Qualification assessment color-coded status
/// </summary>
public enum AssessmentStatus
{
    /// <summary>
    /// Draft - not yet assessed
    /// </summary>
    Draft = 0,
    
    /// <summary>
    /// Green - fully qualified, no gaps
    /// </summary>
    Qualified = 1,
    
    /// <summary>
    /// Yellow - minor gaps, requires manager review
    /// </summary>
    NeedsReview = 2,
    
    /// <summary>
    /// Red - critical gaps, not qualified
    /// </summary>
    NotQualified = 3,
    
    /// <summary>
    /// Manager approved despite gaps (requires justification)
    /// </summary>
    ManagerApproved = 4,
    
    /// <summary>
    /// Rejected by manager
    /// </summary>
    Rejected = 5,
    
    /// <summary>
    /// Published to Auditor Portal
    /// </summary>
    Published = 6
}
