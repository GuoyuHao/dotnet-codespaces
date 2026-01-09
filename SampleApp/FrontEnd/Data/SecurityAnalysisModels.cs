namespace FrontEnd.Data;

public class ExposureAnalysisData
{
    public required string AccountName { get; set; }
    public int TotalNodes { get; set; }
    public int CriticalAssets { get; set; }
    public required string RiskScore { get; set; }
    public bool HasVulnerabilities { get; set; }
    public List<ExposedNode> ExposedNodes { get; set; } = new();
}

public class ExposedNode
{
    public required string NodeName { get; set; }
    public required string NodeType { get; set; }
    public required string RiskLevel { get; set; }
    public int PathLength { get; set; }
}
