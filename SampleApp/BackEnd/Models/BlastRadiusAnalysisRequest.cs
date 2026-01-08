namespace BackEnd.Models;

/// <summary>
/// Request model for blast radius security analysis
/// </summary>
public record BlastRadiusAnalysisRequest
{
    /// <summary>
    /// The target account name or identifier to analyze
    /// </summary>
    public string TargetName { get; init; } = string.Empty;
    
    /// <summary>
    /// Minimum path length for the analysis (default: 1)
    /// </summary>
    public int MinPathLength { get; init; } = 1;
    
    /// <summary>
    /// Maximum path length for the analysis (default: 5)
    /// </summary>
    public int MaxPathLength { get; init; } = 5;
    
    /// <summary>
    /// Maximum number of results to return (default: 1000)
    /// </summary>
    public int ResultsCountLimit { get; init; } = 1000;
}
