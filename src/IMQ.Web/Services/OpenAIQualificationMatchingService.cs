using IMQ.Core.Data;
using IMQ.Core.Interfaces;
using System.Text;
using System.Text.Json;

namespace IMQ.Web.Services;

/// <summary>
/// OpenAI-powered qualification matching service using text embeddings
/// </summary>
public class OpenAIQualificationMatchingService : IQualificationMatchingService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OpenAIQualificationMatchingService> _logger;
    private Dictionary<string, float[]>? _cachedEmbeddings;
    private readonly SemaphoreSlim _initializationLock = new(1, 1);

    public OpenAIQualificationMatchingService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<OpenAIQualificationMatchingService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<List<QualificationMatch>> FindMatchesAsync(
        string userInput, 
        int topK = 3, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            return new List<QualificationMatch>();
        }

        try
        {
            // Ensure embeddings are initialized
            await EnsureEmbeddingsInitializedAsync(cancellationToken);

            if (_cachedEmbeddings == null || _cachedEmbeddings.Count == 0)
            {
                _logger.LogWarning("Embeddings not initialized, returning empty matches");
                return new List<QualificationMatch>();
            }

            // Get embedding for user input
            var userEmbedding = await GetEmbeddingAsync(userInput, cancellationToken);
            if (userEmbedding == null)
            {
                return new List<QualificationMatch>();
            }

            // Calculate cosine similarity with all master titles
            var similarities = new List<(string Title, double Score)>();
            foreach (var kvp in _cachedEmbeddings)
            {
                var similarity = CosineSimilarity(userEmbedding, kvp.Value);
                similarities.Add((kvp.Key, similarity));
            }

            // Return top K matches
            var topMatches = similarities
                .OrderByDescending(x => x.Score)
                .Take(topK)
                .Select(x => new QualificationMatch
                {
                    Title = x.Title,
                    SimilarityScore = x.Score
                })
                .ToList();

            _logger.LogInformation("Found {Count} matches for '{Input}', top score: {Score:F3}", 
                topMatches.Count, userInput, topMatches.FirstOrDefault()?.SimilarityScore ?? 0);

            return topMatches;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finding matches for '{Input}'", userInput);
            return new List<QualificationMatch>();
        }
    }

    private async Task EnsureEmbeddingsInitializedAsync(CancellationToken cancellationToken)
    {
        if (_cachedEmbeddings != null)
        {
            return;
        }

        await _initializationLock.WaitAsync(cancellationToken);
        try
        {
            if (_cachedEmbeddings != null)
            {
                return; // Another thread initialized it
            }

            _logger.LogInformation("Initializing embeddings for {Count} master qualification titles", 
                MasterQualificationList.StandardTitles.Count);

            _cachedEmbeddings = new Dictionary<string, float[]>();

            // Batch process embeddings (OpenAI allows up to 2048 texts per request)
            var batchSize = 100;
            for (int i = 0; i < MasterQualificationList.StandardTitles.Count; i += batchSize)
            {
                var batch = MasterQualificationList.StandardTitles
                    .Skip(i)
                    .Take(batchSize)
                    .ToList();

                var embeddings = await GetEmbeddingsBatchAsync(batch, cancellationToken);
                
                for (int j = 0; j < batch.Count && j < embeddings.Count; j++)
                {
                    _cachedEmbeddings[batch[j]] = embeddings[j];
                }
            }

            _logger.LogInformation("Successfully initialized {Count} embeddings", _cachedEmbeddings.Count);
        }
        finally
        {
            _initializationLock.Release();
        }
    }

    private async Task<float[]?> GetEmbeddingAsync(string text, CancellationToken cancellationToken)
    {
        var batch = await GetEmbeddingsBatchAsync(new List<string> { text }, cancellationToken);
        return batch.FirstOrDefault();
    }

    private async Task<List<float[]>> GetEmbeddingsBatchAsync(List<string> texts, CancellationToken cancellationToken)
    {
        try
        {
            var apiKey = _configuration["OpenAI:ApiKey"] 
                      ?? _configuration["OpenAI__ApiKey"]
                      ?? Environment.GetEnvironmentVariable("OpenAI__ApiKey")
                      ?? Environment.GetEnvironmentVariable("OpenAI:ApiKey");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                _logger.LogWarning("OpenAI API key not configured for embeddings");
                return new List<float[]>();
            }

            var requestBody = new
            {
                input = texts,
                model = "text-embedding-3-small" // More cost-effective than ada-002
            };

            var requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/embeddings",
                content,
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogError("OpenAI embeddings API error: {StatusCode} - {Error}", response.StatusCode, error);
                return new List<float[]>();
            }

            var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
            var apiResponse = JsonSerializer.Deserialize<JsonElement>(responseJson);
            
            var embeddings = new List<float[]>();
            var dataArray = apiResponse.GetProperty("data");
            
            foreach (var item in dataArray.EnumerateArray())
            {
                var embeddingArray = item.GetProperty("embedding");
                var embedding = embeddingArray.EnumerateArray()
                    .Select(e => (float)e.GetDouble())
                    .ToArray();
                embeddings.Add(embedding);
            }

            return embeddings;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting embeddings for {Count} texts", texts.Count);
            return new List<float[]>();
        }
    }

    private static double CosineSimilarity(float[] a, float[] b)
    {
        if (a.Length != b.Length)
        {
            throw new ArgumentException("Vectors must have same length");
        }

        double dotProduct = 0;
        double magnitudeA = 0;
        double magnitudeB = 0;

        for (int i = 0; i < a.Length; i++)
        {
            dotProduct += a[i] * b[i];
            magnitudeA += a[i] * a[i];
            magnitudeB += b[i] * b[i];
        }

        magnitudeA = Math.Sqrt(magnitudeA);
        magnitudeB = Math.Sqrt(magnitudeB);

        if (magnitudeA == 0 || magnitudeB == 0)
        {
            return 0;
        }

        return dotProduct / (magnitudeA * magnitudeB);
    }
}
