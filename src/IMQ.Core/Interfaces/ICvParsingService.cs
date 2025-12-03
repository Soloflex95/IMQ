namespace IMQ.Core.Interfaces;

/// <summary>
/// AI/NLP service for parsing CVs and extracting structured qualification data
/// </summary>
public interface ICvParsingService
{
    /// <summary>
    /// Parse CV text and extract structured data (years of experience, skills, certifications)
    /// </summary>
    /// <param name="cvText">Raw CV/resume text</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Parsed qualification data</returns>
    Task<ParsedCvData> ParseCvAsync(string cvText, CancellationToken cancellationToken = default);
}

/// <summary>
/// Structured data extracted from CV by AI/NLP engine
/// </summary>
public class ParsedCvData
{
    public decimal TotalYearsExperience { get; set; }
    public Dictionary<string, decimal> SkillYears { get; set; } = new();
    public List<ParsedCertification> Certifications { get; set; } = new();
    public List<string> TrainingCourses { get; set; } = new();
    public string? Summary { get; set; }
}

public class ParsedCertification
{
    public string Name { get; set; } = string.Empty;
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? IssuingOrganization { get; set; }
}
