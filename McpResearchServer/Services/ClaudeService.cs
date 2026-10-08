using Anthropic.Models.Messages;
using Anthropic.Models.Organization.ApiKeys;
using Anthropic;

namespace McpResearchServer.Services;

public class ClaudeService(AnthropicClient client, IConfiguration configuration) : IClaudeService
{
    private readonly AnthropicClient _client = client;
    private readonly IConfiguration _configuration = configuration;

    public async Task<string> AnalyzeTextAsync(string text, CancellationToken cancellationToken = default)
    {
        var prompt = $"""
            Summarize the following text clearyly and concisely:
            {text}
            """;

        return await SendMessageAsync(prompt, cancellationToken);
    }

    public async Task<string> SummarizeTextAsync(string text, CancellationToken cancellationToken = default)
    {
        var prompt = $"""
            Analyze the following text.
            Identify the main ideas, key points, and any important details.
            {text}
            """;

        return await SendMessageAsync(prompt, cancellationToken);
    }

    private async Task<string> SendMessageAsync(string prompt, CancellationToken cancellationToken)
    {
        MessageCreateParams parameters = new()
        {
            MaxTokens = 1024,
            Messages = [
                new MessageParam(){
                    Role = Role.User,
                    Content = prompt
                }
            ],
            Model = _configuration["Anthropic:Model"] ??
                throw new InvalidOperationException("Claude model is not configured")
        };

        var message = await _client.Messages.Create(parameters, cancellationToken);

        var texts = new List<string>();

        foreach(var block in message.Content)
        {
            if (block.TryPickText(out var textBlock))
            {
                texts.Add(textBlock.Text);
            }
        }

        return string.Join("\n", texts);
    }
}
