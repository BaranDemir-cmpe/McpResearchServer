using McpResearchServer.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace McpResearchServer.Tools;

[McpServerToolType]
public static class SummarizeTool
{
    [McpServerTool]
    [Description("Summarizes the input text.")]
    public static async Task<string> SummarizeTextAsync(string text, IClaudeService claudeService, CancellationToken cancellationToken)
    {
        return await claudeService.SummarizeTextAsync(text, cancellationToken);
    }
}
