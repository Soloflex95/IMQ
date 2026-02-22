using IMQ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMQ.Api.Controllers;

[ApiController]
[Route("api/cv-analysis")]
public class CvAnalysisController : ControllerBase
{
    private readonly ICvQualificationAnalysisService _cvQualificationAnalysisService;

    public CvAnalysisController(ICvQualificationAnalysisService cvQualificationAnalysisService)
    {
        _cvQualificationAnalysisService = cvQualificationAnalysisService;
    }

    [HttpPost("analyze")]
    [ProducesResponseType(typeof(CvQualificationAnalysisResult), 200)]
    [ProducesResponseType(400)]
    public IActionResult Analyze([FromBody] CvAnalysisRequest request)
    {
        if ((request.ExtractedEvidence == null || request.ExtractedEvidence.Count == 0)
            && string.IsNullOrWhiteSpace(request.CvText))
        {
            return BadRequest(new { error = "Either cvText or extractedEvidence is required" });
        }

        var result = !string.IsNullOrWhiteSpace(request.CvText)
            ? _cvQualificationAnalysisService.AnalyzeFromCvText(request.CvText)
            : _cvQualificationAnalysisService.AnalyzeFromEvidence(request.ExtractedEvidence!);

        return Ok(result);
    }

    [HttpPost("sample")]
    [ProducesResponseType(typeof(CvQualificationAnalysisResult), 200)]
    public IActionResult AnalyzeSample()
    {
        var result = _cvQualificationAnalysisService.AnalyzeSampleCv();
        return Ok(result);
    }
}