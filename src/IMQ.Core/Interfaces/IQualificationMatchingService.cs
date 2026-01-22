namespace IMQ.Core.Interfaces;

/// <summary>
/// Service for matching user-entered qualification titles to standardized master list
/// </summary>
public interface IQualificationMatchingService
{
    /// <summary>
    /// Find the best matching standardized qualification titles for user input
    /// </summary>
    /// <param name="userInput">User-entered qualification title</param>
    /// <param name="topK">Number of top matches to return (default 3)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of matching titles with similarity scores</returns>
    Task<List<QualificationMatch>> FindMatchesAsync(
        string userInput, 
        int topK = 3, 
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Result of qualification title matching
/// </summary>
public class QualificationMatch
{
    /// <summary>
    /// Standardized qualification title from master list
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Similarity score (0.0 to 1.0, higher is better match)
    /// </summary>
    public double SimilarityScore { get; set; }
}
