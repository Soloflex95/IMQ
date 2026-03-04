using IMQ.Core.Entities;

namespace IMQ.Core.Interfaces;

public interface IComplianceAlertService
{
    IReadOnlyList<ComplianceAlert> GetUnresolvedAlerts();
    int GetUnresolvedAlertCount();
}
