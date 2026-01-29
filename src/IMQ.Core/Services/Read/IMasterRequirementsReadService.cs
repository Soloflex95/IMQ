using IMQ.Core.Entities;
using IMQ.Core.Enums;

namespace IMQ.Core.Services.Read;

public interface IMasterRequirementsReadService
{
    IReadOnlyCollection<QualificationRequirement> GetAll();

    IReadOnlyCollection<QualificationRequirement> GetByType(RequirementType type);

    IReadOnlyCollection<QualificationRequirement> GetByApprovalStatus(
        RequirementApprovalStatus status);
}
