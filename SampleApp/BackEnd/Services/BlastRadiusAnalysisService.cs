using BackEnd.Models;
using System.Text.Json;

namespace BackEnd.Services;

/// <summary>
/// Service for performing blast radius security analysis
/// This service integrates with Microsoft Security Graph to analyze exposure perimeters
/// </summary>
public class BlastRadiusAnalysisService : IBlastRadiusAnalysisService
{
    private readonly ILogger<BlastRadiusAnalysisService> _logger;

    public BlastRadiusAnalysisService(ILogger<BlastRadiusAnalysisService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Analyzes the blast radius for a given target
    /// </summary>
    public async Task<BlastRadiusAnalysisResponse> AnalyzeBlastRadiusAsync(BlastRadiusAnalysisRequest request)
    {
        _logger.LogInformation("Starting blast radius analysis for target: {TargetName}", request.TargetName);

        try
        {
            // In a real-world scenario, this would call the Microsoft Security Graph API
            // For this implementation, we're simulating the analysis
            var nodes = await GetExposurePerimeterNodesAsync(request);

            var response = new BlastRadiusAnalysisResponse
            {
                TargetName = request.TargetName,
                Nodes = nodes,
                TotalExposedNodes = nodes.Count,
                AnalysisTimestamp = DateTime.UtcNow
            };

            _logger.LogInformation("Blast radius analysis completed for {TargetName}. Found {Count} exposed nodes", 
                request.TargetName, nodes.Count);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error performing blast radius analysis for {TargetName}", request.TargetName);
            throw;
        }
    }

    /// <summary>
    /// Gets the blast radius for Alberto Polak's account
    /// </summary>
    public async Task<BlastRadiusAnalysisResponse> GetAlbertoPolakBlastRadiusAsync()
    {
        var request = new BlastRadiusAnalysisRequest
        {
            TargetName = "Alberto Polak",
            MinPathLength = 1,
            MaxPathLength = 5,
            ResultsCountLimit = 1000
        };

        return await AnalyzeBlastRadiusAsync(request);
    }

    /// <summary>
    /// Simulates querying the exposure perimeter from Microsoft Security Graph
    /// In production, this would make actual API calls to the security graph service
    /// </summary>
    private async Task<List<ExposureNode>> GetExposurePerimeterNodesAsync(BlastRadiusAnalysisRequest request)
    {
        // Simulate async operation
        await Task.Delay(100);

        // Return mock data demonstrating the blast radius for Alberto Polak
        // In production, this would be replaced with actual Microsoft Security Graph API calls
        var nodes = new List<ExposureNode>();

        if (request.TargetName.Equals("Alberto Polak", StringComparison.OrdinalIgnoreCase))
        {
            // Simulated exposure perimeter for Alberto Polak's account
            nodes.Add(new ExposureNode
            {
                NodeId = "user-001",
                NodeName = "Alberto Polak",
                NodeLabel = "User",
                EntityIds = "alberto.polak@contoso.com",
                Criticality = "High",
                RiskScore = "85",
                HasVulnerabilities = false,
                NumberOfAllNeighbors = 5,
                Edges = "[]"
            });

            nodes.Add(new ExposureNode
            {
                NodeId = "vm-001",
                NodeName = "ProductionWebServer01",
                NodeLabel = "VirtualMachine",
                EntityIds = "/subscriptions/sub-123/resourceGroups/rg-prod/providers/Microsoft.Compute/virtualMachines/vm-001",
                Criticality = "Critical",
                RiskScore = "95",
                HasVulnerabilities = true,
                NumberOfAllNeighbors = 12,
                Edges = "[{\"source\":\"user-001\",\"target\":\"vm-001\",\"type\":\"CanAccess\"}]"
            });

            nodes.Add(new ExposureNode
            {
                NodeId = "storage-001",
                NodeName = "CustomerDataStorage",
                NodeLabel = "StorageAccount",
                EntityIds = "/subscriptions/sub-123/resourceGroups/rg-prod/providers/Microsoft.Storage/storageAccounts/custdata001",
                Criticality = "Critical",
                RiskScore = "90",
                HasVulnerabilities = false,
                NumberOfAllNeighbors = 8,
                Edges = "[{\"source\":\"user-001\",\"target\":\"storage-001\",\"type\":\"CanRead\"}]"
            });

            nodes.Add(new ExposureNode
            {
                NodeId = "db-001",
                NodeName = "ProductionDatabase",
                NodeLabel = "SqlDatabase",
                EntityIds = "/subscriptions/sub-123/resourceGroups/rg-prod/providers/Microsoft.Sql/servers/sql-prod/databases/maindb",
                Criticality = "Critical",
                RiskScore = "92",
                HasVulnerabilities = false,
                NumberOfAllNeighbors = 6,
                Edges = "[{\"source\":\"user-001\",\"target\":\"db-001\",\"type\":\"CanExecute\"}]"
            });

            nodes.Add(new ExposureNode
            {
                NodeId = "keyvault-001",
                NodeName = "ProductionSecrets",
                NodeLabel = "KeyVault",
                EntityIds = "/subscriptions/sub-123/resourceGroups/rg-prod/providers/Microsoft.KeyVault/vaults/kv-prod-001",
                Criticality = "Critical",
                RiskScore = "88",
                HasVulnerabilities = false,
                NumberOfAllNeighbors = 15,
                Edges = "[{\"source\":\"user-001\",\"target\":\"keyvault-001\",\"type\":\"CanListSecrets\"}]"
            });
        }

        return nodes;
    }
}
