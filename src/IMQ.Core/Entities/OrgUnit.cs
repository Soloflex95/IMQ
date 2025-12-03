namespace IMQ.Core.Entities;

/// <summary>
/// Organizational unit (Company → Division → Department hierarchy)
/// </summary>
public class OrgUnit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
    public string? Description { get; set; }
    
    /// <summary>
    /// Parent org unit for hierarchical structure
    /// </summary>
    public Guid? ParentId { get; set; }
    public OrgUnit? Parent { get; set; }
    
    /// <summary>
    /// Child org units
    /// </summary>
    public ICollection<OrgUnit> Children { get; set; } = new List<OrgUnit>();
    
    /// <summary>
    /// Workers in this org unit
    /// </summary>
    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
