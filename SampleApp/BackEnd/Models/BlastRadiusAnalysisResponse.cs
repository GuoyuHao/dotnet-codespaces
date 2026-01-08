namespace BackEnd.Models;

/// <summary>
/// Response model for blast radius security analysis
/// </summary>
public record BlastRadiusAnalysisResponse
{
    /// <summary>
    /// The target that was analyzed
    /// </summary>
    public string TargetName { get; init; } = string.Empty;
    
    /// <summary>
    /// List of nodes in the blast radius
    /// </summary>
    public List<ExposureNode> Nodes { get; init; } = new();
    
    /// <summary>
    /// Total count of exposed nodes
    /// </summary>
    public int TotalExposedNodes { get; init; }
    
    /// <summary>
    /// Timestamp of the analysis
    /// </summary>
    public DateTime AnalysisTimestamp { get; init; } = DateTime.UtcNow;
}

/// <summary>
/// Represents a node in the exposure perimeter
/// </summary>
public record ExposureNode
{
    /// <summary>
    /// Unique identifier for the node
    /// </summary>
    public string NodeId { get; init; } = string.Empty;
    
    /// <summary>
    /// Name of the node
    /// </summary>
    public string NodeName { get; init; } = string.Empty;
    
    /// <summary>
    /// Type/label of the node
    /// </summary>
    public string NodeLabel { get; init; } = string.Empty;
    
    /// <summary>
    /// Entity identifiers associated with this node
    /// </summary>
    public string EntityIds { get; init; } = string.Empty;
    
    /// <summary>
    /// Criticality level of the node
    /// </summary>
    public string Criticality { get; init; } = string.Empty;
    
    /// <summary>
    /// Risk score of the node
    /// </summary>
    public string RiskScore { get; init; } = string.Empty;
    
    /// <summary>
    /// Whether the node has known vulnerabilities
    /// </summary>
    public bool HasVulnerabilities { get; init; }
    
    /// <summary>
    /// Number of neighboring nodes
    /// </summary>
    public long NumberOfAllNeighbors { get; init; }
    
    /// <summary>
    /// Edges connecting to this node
    /// </summary>
    public string Edges { get; init; } = string.Empty;
}
