namespace IMQ.Core.Interfaces;

/// <summary>
/// Service for parsing unstructured documents (CVs, certificates) into structured data using AI
/// </summary>
public interface IDocumentParsingService
{
    /// <summary>
    /// Extract qualifications from a document
    /// </summary>
    /// <param name="fileStream">Document file stream</param>
    /// <param name="fileName">Original file name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of extracted qualifications</returns>
    Task<DocumentParseResult> ParseDocumentAsync(
        Stream fileStream,
        string fileName,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Result of document parsing operation
/// </summary>
public class DocumentParseResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public List<ExtractedQualification> Qualifications { get; set; } = new();
    public string? RoleSummary { get; set; }
}

/// <summary>
/// Qualification data extracted from document
/// </summary>
public class ExtractedQualification
{
    public string SkillName { get; set; } = string.Empty;
    public DateTime? DateAcquired { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? IssuingAuthority { get; set; }
    public string? CertificateNumber { get; set; }
    public double ConfidenceScore { get; set; }
}
