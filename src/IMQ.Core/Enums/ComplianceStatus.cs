namespace IMQ.Core.Enums;

/// <summary>
/// Compliance status result from matching qualifications against job requirements
/// </summary>
public enum ComplianceStatus
{
    Qualified = 0,
    GapDetected = 1,
    Expired = 2
}
