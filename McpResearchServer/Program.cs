using Anthropic;
using McpResearchServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly();

builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var apiKey = configuration["Anthropic:ApiKey"]
        ?? throw new InvalidOperationException("Claude API key is not configured.");

    return new AnthropicClient
    {
        ApiKey = apiKey
    };
});

builder.Services.AddScoped<IClaudeService, ClaudeService>();


var app = builder.Build();

app.MapMcp("/mcp");

await app.RunAsync();