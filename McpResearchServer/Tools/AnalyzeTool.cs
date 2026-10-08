using McpResearchServer.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace McpResearchServer.Tools;

[McpServerToolType]
public static class AnalyzeTool
{
    [McpServerTool]
    [Description("Analyzes the given text using Claude AI.")]
    public static async Task<string> AnalyzeTextAsync(string text, IClaudeService claudeService, CancellationToken cancellationToken)
    {
        return await claudeService.AnalyzeTextAsync(text, cancellationToken);
    }   
}
