namespace FrontEnd.Data;

public class ExposureAnalysisData
{
    public string AccountName { get; set; } = "";
    public int TotalNodes { get; set; }
    public int CriticalAssets { get; set; }
    public string RiskScore { get; set; } = "Unknown";
    public bool HasVulnerabilities { get; set; }
    public List<ExposedNode> ExposedNodes { get; set; } = new();
}

public class ExposedNode
{
    public string NodeName { get; set; } = "";
    public string NodeType { get; set; } = "";
    public string RiskLevel { get; set; } = "";
    public int PathLength { get; set; }
}
