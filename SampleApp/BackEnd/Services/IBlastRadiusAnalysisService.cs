using BackEnd.Models;

namespace BackEnd.Services;

/// <summary>
/// Interface for blast radius security analysis service
/// </summary>
public interface IBlastRadiusAnalysisService
{
    /// <summary>
    /// Analyzes the blast radius for a given target
    /// </summary>
    /// <param name="request">The analysis request parameters</param>
    /// <returns>The blast radius analysis results</returns>
    Task<BlastRadiusAnalysisResponse> AnalyzeBlastRadiusAsync(BlastRadiusAnalysisRequest request);
    
    /// <summary>
    /// Gets the blast radius for Alberto Polak's account
    /// </summary>
    /// <returns>The blast radius analysis for Alberto Polak</returns>
    Task<BlastRadiusAnalysisResponse> GetAlbertoPolakBlastRadiusAsync();
}
