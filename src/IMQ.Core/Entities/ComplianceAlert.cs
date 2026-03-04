using IMQ.Core.Enums;

namespace IMQ.Core.Entities;

public class ComplianceAlert
{
    public string AlertId { get; set; } = string.Empty;
    public string WorkerName { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string Issue { get; set; } = string.Empty;
    public AlertSeverity Severity { get; set; }
    public int? DaysOverdue { get; set; }
    public string ImpactDescription { get; set; } = string.Empty;
}
