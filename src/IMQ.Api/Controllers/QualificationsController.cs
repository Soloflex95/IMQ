using IMQ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMQ.Api.Controllers;

/// <summary>
/// API controller for qualification management
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class QualificationsController : ControllerBase
{
    private readonly IQualificationMatchingService _matchingService;
    private readonly ILogger<QualificationsController> _logger;

    public QualificationsController(
        IQualificationMatchingService matchingService,
        ILogger<QualificationsController> logger)
    {
        _matchingService = matchingService;
        _logger = logger;
    }

    /// <summary>
    /// Find standardized qualification title matches for user input
    /// </summary>
    /// <param name="query">User-entered qualification title</param>
    /// <param name="topK">Number of top matches to return (default 3)</param>
    /// <returns>List of matching standardized titles with similarity scores</returns>
    [HttpGet("match")]
    [ProducesResponseType(typeof(List<QualificationMatch>), 200)]
    public async Task<IActionResult> MatchQualification(
        [FromQuery] string query,
        [FromQuery] int topK = 3,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest(new { error = "Query parameter is required" });
        }

        if (topK < 1 || topK > 10)
        {
            return BadRequest(new { error = "topK must be between 1 and 10" });
        }

        try
        {
            var matches = await _matchingService.FindMatchesAsync(query, topK, cancellationToken);
            return Ok(matches);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error matching qualification for query: {Query}", query);
            return StatusCode(500, new { error = "Internal server error" });
        }
    }
}
