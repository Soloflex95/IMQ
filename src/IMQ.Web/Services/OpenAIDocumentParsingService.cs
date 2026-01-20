using IMQ.Core.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace IMQ.Web.Services;

public class OpenAIDocumentParsingService : IDocumentParsingService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OpenAIDocumentParsingService> _logger;

    public OpenAIDocumentParsingService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<OpenAIDocumentParsingService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<DocumentParseResult> ParseDocumentAsync(
        Stream fileStream,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Processing document: {FileName}", fileName);

            var apiKey = _configuration["OpenAI:ApiKey"];
            var model = _configuration["OpenAI:Model"] ?? "gpt-4o-mini";

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                _logger.LogWarning("OpenAI API key not configured, using mock data");
                return GetMockExtractionResult(fileName);
            }

            // Extract text from document based on file type
            var documentText = await ExtractTextFromDocument(fileStream, fileName, cancellationToken);

            if (string.IsNullOrWhiteSpace(documentText))
            {
                return new DocumentParseResult
                {
                    Success = false,
                    ErrorMessage = "Document is empty or could not be read"
                };
            }

            // Limit text size to avoid token limits
            if (documentText.Length > 8000)
            {
                documentText = documentText.Substring(0, 8000);
                _logger.LogInformation("Document truncated to 8000 characters");
            }

            var prompt = BuildExtractionPrompt(documentText);

            var requestBody = new
            {
                model = model,
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = "You are an expert at extracting qualifications, certifications, and training information from resumes and certificates. Always respond with valid JSON only, no markdown formatting."
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                temperature = 0.1,
                max_tokens = 2000
            };

            var requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                content,
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogError("OpenAI API error: {StatusCode} - {Error}", response.StatusCode, error);
                return new DocumentParseResult
                {
                    Success = false,
                    ErrorMessage = $"AI service error: {response.StatusCode}"
                };
            }

            var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
            var aiResponse = JsonSerializer.Deserialize<JsonElement>(responseJson);
            
            var extractedText = aiResponse.GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            var (qualifications, roleSummary) = ParseExtractedJson(extractedText);

            _logger.LogInformation("Successfully extracted {Count} qualifications from {FileName}", 
                qualifications.Count, fileName);

            return new DocumentParseResult
            {
                Success = true,
                Qualifications = qualifications,
                RoleSummary = roleSummary
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing document {FileName}", fileName);
            return new DocumentParseResult
            {
                Success = false,
                ErrorMessage = $"Parsing error: {ex.Message}"
            };
        }
    }

    private string BuildExtractionPrompt(string documentText)
    {
        return $@"Extract ALL qualifications, certifications, training courses, licenses, and relevant skills from this document.

For each qualification found, extract:
- The name of the skill, certification, or training
- Date acquired (if mentioned)
- Expiration date (if mentioned)
- Issuing organization
- Certificate or license number (if mentioned)

Also, provide a 1-paragraph summary (2-3 sentences) about what roles this person would be most suited for in a health sciences clinical study based on their qualifications.

Return ONLY a JSON object with this structure (no markdown, no explanation):

{{
  ""roleSummary"": ""Based on the qualifications, this person is well-suited for..."",
  ""qualifications"": [
    {{
      ""skillName"": ""Name of certification or skill"",
      ""dateAcquired"": ""2024-01-15"",
      ""expirationDate"": ""2027-01-15"",
      ""issuingAuthority"": ""Organization name"",
      ""certificateNumber"": ""CERT-12345"",
      ""confidenceScore"": 0.95
    }}
  ]
}}

If a field is not found, use null. Set confidenceScore between 0.7-1.0 based on how clear the information is.

Document content:
{documentText}

Return ONLY the JSON array, nothing else.";
    }

    private (List<ExtractedQualification>, string?) ParseExtractedJson(string? jsonText)
    {
        if (string.IsNullOrWhiteSpace(jsonText))
        {
            return (new List<ExtractedQualification>(), null);
        }

        try
        {
            // Clean up markdown formatting if present
            var cleaned = jsonText.Trim();
            cleaned = Regex.Replace(cleaned, @"```json\s*", "");
            cleaned = Regex.Replace(cleaned, @"```\s*", "");
            cleaned = cleaned.Trim();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var rootElement = JsonSerializer.Deserialize<JsonElement>(cleaned, options);

            // Extract role summary
            string? roleSummary = null;
            if (rootElement.TryGetProperty("roleSummary", out var summaryElement))
            {
                roleSummary = summaryElement.GetString();
            }

            // Extract qualifications array
            List<ExtractedQualification> qualifications;
            if (rootElement.TryGetProperty("qualifications", out var qualificationsElement))
            {
                qualifications = JsonSerializer.Deserialize<List<ExtractedQualification>>(
                    qualificationsElement.GetRawText(), options) ?? new List<ExtractedQualification>();
            }
            else
            {
                qualifications = new List<ExtractedQualification>();
            }

            return (qualifications, roleSummary);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse extracted JSON: {Json}", jsonText?.Substring(0, Math.Min(500, jsonText?.Length ?? 0)));
            return (new List<ExtractedQualification>(), null);
        }
    }

    private DocumentParseResult GetMockExtractionResult(string fileName)
    {
        _logger.LogInformation("Using mock extraction for {FileName}", fileName);

        return new DocumentParseResult
        {
            Success = true,
            Qualifications = new List<ExtractedQualification>
            {
                new()
                {
                    SkillName = "GMP Training",
                    DateAcquired = DateTime.UtcNow.AddYears(-2),
                    ExpirationDate = DateTime.UtcNow.AddYears(1),
                    IssuingAuthority = "Pharmaceutical Training Institute",
                    CertificateNumber = "GMP-2024-001",
                    ConfidenceScore = 0.95
                },
                new()
                {
                    SkillName = "Quality Auditing",
                    DateAcquired = DateTime.UtcNow.AddYears(-1),
                    ExpirationDate = null,
                    IssuingAuthority = "ASQ - American Society for Quality",
                    CertificateNumber = "ASQ-QA-2025-456",
                    ConfidenceScore = 0.92
                }
            }
        };
    }

    private async Task<string> ExtractTextFromDocument(Stream fileStream, string fileName, CancellationToken cancellationToken)
    {
        var extension = System.IO.Path.GetExtension(fileName).ToLowerInvariant();

        try
        {
            switch (extension)
            {
                case ".txt":
                    using (var reader = new StreamReader(fileStream))
                    {
                        return await reader.ReadToEndAsync(cancellationToken);
                    }

                case ".pdf":
                    return ExtractTextFromPdf(fileStream);

                case ".docx":
                case ".doc":
                    return ExtractTextFromDocx(fileStream);

                default:
                    _logger.LogWarning("Unsupported file type: {Extension}", extension);
                    return string.Empty;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting text from {FileName}", fileName);
            return string.Empty;
        }
    }

    private string ExtractTextFromPdf(Stream pdfStream)
    {
        var text = new StringBuilder();

        try
        {
            using var document = PdfDocument.Open(pdfStream);
            foreach (var page in document.GetPages())
            {
                text.AppendLine(page.Text);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting text from PDF");
            text.AppendLine("[PDF text extraction failed - file may be scanned, encrypted, or corrupted]");
        }

        return text.ToString();
    }

    private string ExtractTextFromDocx(Stream docxStream)
    {
        var text = new StringBuilder();

        using var doc = WordprocessingDocument.Open(docxStream, false);
        var body = doc.MainDocumentPart?.Document?.Body;

        if (body != null)
        {
            foreach (var paragraph in body.Elements<Paragraph>())
            {
                text.AppendLine(paragraph.InnerText);
            }
        }

        return text.ToString();
    }
}
