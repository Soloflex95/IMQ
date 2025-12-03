namespace IMQ.Core.Entities;

/// <summary>
/// Immutable audit trail for 21 CFR Part 11 compliance
/// </summary>
public class AuditLog
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// Tenant ID for multi-tenancy
    /// </summary>
    public Guid TenantId { get; set; }
    
    /// <summary>
    /// Entity type (e.g., "Qualification", "Assessment")
    /// </summary>
    public string EntityType { get; set; } = string.Empty;
    
    /// <summary>
    /// Entity ID that was modified
    /// </summary>
    public Guid EntityId { get; set; }
    
    /// <summary>
    /// Action performed (Create, Update, Delete, Approve, Override, Publish)
    /// </summary>
    public string Action { get; set; } = string.Empty;
    
    /// <summary>
    /// User ID who performed the action
    /// </summary>
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// Username for readability
    /// </summary>
    public string UserName { get; set; } = string.Empty;
    
    /// <summary>
    /// UTC timestamp (ISO 8601)
    /// </summary>
    public DateTime Timestamp { get; set; }
    
    /// <summary>
    /// Old values (JSON)
    /// </summary>
    public string? OldValues { get; set; }
    
    /// <summary>
    /// New values (JSON)
    /// </summary>
    public string? NewValues { get; set; }
    
    /// <summary>
    /// Reason code (for e-signature)
    /// </summary>
    public string? ReasonCode { get; set; }
    
    /// <summary>
    /// Additional context (e.g., override justification)
    /// </summary>
    public string? Notes { get; set; }
    
    /// <summary>
    /// IP address for security tracking
    /// </summary>
    public string? IpAddress { get; set; }
}
