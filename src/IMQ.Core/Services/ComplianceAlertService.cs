using IMQ.Core.Entities;
using IMQ.Core.Enums;
using IMQ.Core.Interfaces;

namespace IMQ.Core.Services;

public class ComplianceAlertService : IComplianceAlertService
{
    private static readonly DateTime DemoToday = new(2026, 3, 1);

    public IReadOnlyList<ComplianceAlert> GetUnresolvedAlerts()
    {
        var alerts = GetCanonicalAlerts()
            .Select(ToComplianceAlert)
            .OrderBy(alert => alert.Severity)
            .ThenByDescending(alert => alert.DaysOverdue.HasValue)
            .ThenByDescending(alert => alert.DaysOverdue)
            .ThenBy(alert => alert.WorkerName, StringComparer.Ordinal)
            .ToList();

        return alerts;
    }

    public int GetUnresolvedAlertCount()
    {
        return GetUnresolvedAlerts().Count;
    }

    private static IEnumerable<CanonicalAlertSeed> GetCanonicalAlerts()
    {
        return
        [
            new CanonicalAlertSeed(
                AlertId: "CA-001",
                WorkerName: "Mike Johnson",
                RoleName: "QA Lead",
                Issue: "Critical training expired",
                Severity: AlertSeverity.High,
                ExpiredOn: new DateTime(2026, 1, 15),
                ImpactDescription: "Authorization blocked for QA Lead duties."),
            new CanonicalAlertSeed(
                AlertId: "CA-003",
                WorkerName: "Robert Chen",
                RoleName: "Quality Specialist",
                Issue: "Missing required qualification evidence",
                Severity: AlertSeverity.High,
                ExpiredOn: null,
                ImpactDescription: "Missing evidence required for role authorization."),
            new CanonicalAlertSeed(
                AlertId: "CA-002",
                WorkerName: "Jane Doe",
                RoleName: "QA Lead",
                Issue: "Assessment override pending justification",
                Severity: AlertSeverity.Medium,
                ExpiredOn: null,
                ImpactDescription: "Override requires justification before authorization is defensible.")
        ];
    }

    private static ComplianceAlert ToComplianceAlert(CanonicalAlertSeed seed)
    {
        var daysOverdue = seed.ExpiredOn.HasValue
            ? (DemoToday.Date - seed.ExpiredOn.Value.Date).Days
            : (int?)null;

        return new ComplianceAlert
        {
            AlertId = seed.AlertId,
            WorkerName = seed.WorkerName,
            RoleName = seed.RoleName,
            Issue = seed.Issue,
            Severity = seed.Severity,
            DaysOverdue = daysOverdue,
            ImpactDescription = seed.ImpactDescription
        };
    }

    private sealed record CanonicalAlertSeed(
        string AlertId,
        string WorkerName,
        string RoleName,
        string Issue,
        AlertSeverity Severity,
        DateTime? ExpiredOn,
        string ImpactDescription);
}
