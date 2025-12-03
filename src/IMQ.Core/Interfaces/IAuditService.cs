using IMQ.Core.Entities;

namespace IMQ.Core.Interfaces;

/// <summary>
/// Audit logging service for 21 CFR Part 11 compliance
/// </summary>
public interface IAuditService
{
    /// <summary>
    /// Log an action to the immutable audit trail
    /// </summary>
    Task LogAsync(string entityType, Guid entityId, string action, string userId, string userName, string? oldValues = null, string? newValues = null, string? reasonCode = null, string? notes = null, string? ipAddress = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieve audit trail for an entity
    /// </summary>
    Task<IEnumerable<AuditLog>> GetAuditTrailAsync(string entityType, Guid entityId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Generate audit report for date range
    /// </summary>
    Task<IEnumerable<AuditLog>> GenerateReportAsync(DateTime startDate, DateTime endDate, string? entityType = null, CancellationToken cancellationToken = default);
}
