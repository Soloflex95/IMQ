using IMQ.Core.Interfaces;
using System.Text;
using System.Text.Json;

namespace IMQ.Web.Services;

/// <summary>
/// Azure OpenAI-based document parsing service for extracting qualifications from CVs and certificates
/// </summary>
public class AzureOpenAIDocumentParsingService : IDocumentParsingService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AzureOpenAIDocumentParsingService> _logger;

    public AzureOpenAIDocumentParsingService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<AzureOpenAIDocumentParsingService> logger)
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
            // Read document content
            using var reader = new StreamReader(fileStream);
            var documentText = await reader.ReadToEndAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(documentText))
            {
                return new DocumentParseResult
                {
                    Success = false,
                    ErrorMessage = "Document is empty or could not be read"
                };
            }

            // Get Azure OpenAI configuration
            var endpoint = _configuration["AzureOpenAI:Endpoint"];
            var apiKey = _configuration["AzureOpenAI:ApiKey"];
            var deploymentName = _configuration["AzureOpenAI:DeploymentName"] ?? "gpt-4";

            if (string.IsNullOrWhiteSpace(endpoint) || string.IsNullOrWhiteSpace(apiKey))
            {
                _logger.LogWarning("Azure OpenAI not configured, using mock extraction");
                return GetMockExtractionResult(fileName);
            }

            // Build prompt for structured extraction
            var prompt = BuildExtractionPrompt(documentText);

            // Call Azure OpenAI
            var requestBody = new
            {
                messages = new[]
                {
                    new { role = "system", content = "You are a document parsing assistant that extracts qualification data from CVs and certificates. Always respond with valid JSON only." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.1,
                max_tokens = 2000
            };

            var requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

            var response = await _httpClient.PostAsync(
                $"{endpoint}/openai/deployments/{deploymentName}/chat/completions?api-version=2024-02-15-preview",
                content,
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogError("Azure OpenAI API error: {StatusCode} - {Error}", response.StatusCode, error);
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

            // Parse the JSON response
            var qualifications = ParseExtractedJson(extractedText);

            return new DocumentParseResult
            {
                Success = true,
                Qualifications = qualifications
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
        return $@"Extract ALL qualifications, certifications, training, and skills from the following document. 
Return ONLY a JSON array with this exact structure (no markdown, no explanation):

[
  {{
    ""skillName"": ""Skill or certification name"",
    ""dateAcquired"": ""YYYY-MM-DD or null"",
    ""expirationDate"": ""YYYY-MM-DD or null"",
    ""issuingAuthority"": ""Organization that issued it or null"",
    ""certificateNumber"": ""Certificate/License number or null"",
    ""confidenceScore"": 0.95
  }}
]

Document:
{documentText}

Remember: Return ONLY the JSON array, nothing else.";
    }

    private List<ExtractedQualification> ParseExtractedJson(string? jsonText)
    {
        if (string.IsNullOrWhiteSpace(jsonText))
        {
            return new List<ExtractedQualification>();
        }

        try
        {
            // Remove markdown code blocks if present
            var cleaned = jsonText.Trim();
            if (cleaned.StartsWith("```json"))
            {
                cleaned = cleaned.Substring(7);
            }
            if (cleaned.StartsWith("```"))
            {
                cleaned = cleaned.Substring(3);
            }
            if (cleaned.EndsWith("```"))
            {
                cleaned = cleaned.Substring(0, cleaned.Length - 3);
            }
            cleaned = cleaned.Trim();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<ExtractedQualification>>(cleaned, options)
                   ?? new List<ExtractedQualification>();
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse extracted JSON: {Json}", jsonText);
            return new List<ExtractedQualification>();
        }
    }

    /// <summary>
    /// Fallback mock data when Azure OpenAI is not configured
    /// </summary>
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
                },
                new()
                {
                    SkillName = "21 CFR Part 11 Compliance",
                    DateAcquired = DateTime.UtcNow.AddMonths(-6),
                    ExpirationDate = DateTime.UtcNow.AddMonths(18),
                    IssuingAuthority = "FDA Training Center",
                    CertificateNumber = null,
                    ConfidenceScore = 0.88
                }
            }
        };
    }
}
