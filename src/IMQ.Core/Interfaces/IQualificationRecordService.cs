using IMQ.Core.Entities;

namespace IMQ.Core.Interfaces;

/// <summary>
/// Provides structured qualification records for manager review.
/// </summary>
public interface IQualificationRecordService
{
    QualificationRecord GetQualificationRecord(string workerId);

    IReadOnlyList<(string WorkerId, string WorkerName, string Role, string QualificationStatus)> GetTeamSummary();
}
