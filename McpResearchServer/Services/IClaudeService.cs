namespace McpResearchServer.Services;

public interface IClaudeService
{
    Task<string> SummarizeTextAsync(string text, CancellationToken cancellationToken = default);

    Task<string> AnalyzeTextAsync(string text, CancellationToken cancellationToken = default);
}
