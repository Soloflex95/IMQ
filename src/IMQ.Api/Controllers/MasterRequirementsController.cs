using IMQ.Core.Entities;
using IMQ.Core.Enums;
using IMQ.Core.Services.Read;
using Microsoft.AspNetCore.Mvc;

namespace IMQ.Api.Controllers;

[ApiController]
[Route("api/mrl")]
public class MasterRequirementsController : ControllerBase
{
    private readonly IMasterRequirementsReadService _readService;

    public MasterRequirementsController(
        IMasterRequirementsReadService readService)
    {
        _readService = readService;
    }

    [HttpGet]
public ActionResult<IEnumerable<QualificationRequirement>> GetAll()
{
    return Ok(_readService.GetAll());
}

[HttpGet("by-type/{type}")]
public ActionResult<IEnumerable<QualificationRequirement>> GetByType(
    RequirementType type)
{
    return Ok(_readService.GetByType(type));
}

    [HttpGet("by-status/{status}")]
    public ActionResult<IEnumerable<QualificationRequirement>> GetByStatus(
        RequirementApprovalStatus status)
    {
        return Ok(_readService.GetByApprovalStatus(status));
    }
}
