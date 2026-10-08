# McpResearchServer

A simple Model Context Protocol (MCP) server built with **.NET 10, ASP.NET Core, and Anthropic Claude AI**.

The server provides AI-powered text summarization and analysis through MCP tools using Streamable HTTP transport.

## Features

- Text summarization and analysis using Claude AI
- MCP tools exposed via Streamable HTTP
- Anthropic C# SDK integration
- Dependency Injection
- Asynchronous operations with CancellationToken support
- MCP Inspector compatibility

## Technologies

- .NET 10 / C#
- ASP.NET Core
- ModelContextProtocol SDK
- Anthropic C# SDK

## MCP Tools

- **summarize_text** – Summarizes the provided text using Claude AI.
- **analyze_text** – Analyzes text to identify key points and conclusions.

## Configuration

Configure your Anthropic API key and model using .NET User Secrets or `appsettings.json`:

```json
{
  "Anthropic": {
    "ApiKey": "YOUR_API_KEY",
    "Model": "YOUR_MODEL_ID"
  }
}
```

## Running the Project

```bash
git clone https://github.com/BaranDemir-cmpe/McpResearchServer.git
cd McpResearchServer
dotnet run --project McpResearchServer
```

## Testing

Start MCP Inspector:

```bash
npx @modelcontextprotocol/inspector
```

Connect using **Streamable HTTP** at `http://localhost:<PORT>/mcp`.

MCP connectivity and tool execution flow have been tested using MCP Inspector. Successful Claude API responses require valid credentials and have not yet been verified.

## References

- [Model Context Protocol](https://modelcontextprotocol.io/)
- [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Anthropic API](https://platform.claude.com/docs/en/api/overview)
