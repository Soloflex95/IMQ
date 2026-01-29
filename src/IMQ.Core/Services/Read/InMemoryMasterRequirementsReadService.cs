using IMQ.Core.Entities;
using IMQ.Core.Enums;
using System.Linq;


namespace IMQ.Core.Services.Read;

public class InMemoryMasterRequirementsReadService
    : IMasterRequirementsReadService
{
    private readonly InMemoryQualificationRequirementService _source;

    public InMemoryMasterRequirementsReadService()
    {
        _source = new InMemoryQualificationRequirementService();
    }

    public IReadOnlyCollection<QualificationRequirement> GetAll()
    {
        return _source.GetAll();
    }

    public IReadOnlyCollection<QualificationRequirement> GetByType(
        RequirementType type)
    {
        return _source
            .GetAll()
            .Where(r => r.RequirementType == type)
            .ToList();
    }

    public IReadOnlyCollection<QualificationRequirement> GetByApprovalStatus(
        RequirementApprovalStatus status)
    {
        return _source
            .GetAll()
            .Where(r => r.RequirementApprovalStatus == status)
            .ToList();
    }
}
