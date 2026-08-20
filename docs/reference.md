# Reference

Use this page for terms and official links after the workshop.

## Glossary

**Agent mode**: Copilot chat mode where Copilot can plan, edit files, run tools when allowed, and iterate on results.

**Agent Skill**: A folder with a `SKILL.md` file that packages task-specific instructions and optional resources for Copilot to load when relevant.

**Capstone**: A longer lab that combines earlier skills into one practical task.

**Characterization test**: A test that captures current behavior before refactoring, so changes can be checked safely.

**Copilot code review**: Copilot feedback on selected code, local changes, or pull requests depending on environment support.

**Editor-local review**: A Copilot review requested inside the editor without pushing a branch or opening a pull request.

**MCP**: Model Context Protocol, an open standard for connecting AI tools to external tools and data sources.

**Preflight**: The setup check run before the workshop to confirm tools, sign-in, restore, and tests.

**Reference solutions**: Completed lab solutions stored on the separate `reference-solutions` branch, not in the default learner tree.

**Scoped instruction file**: A `.instructions.md` file that applies Copilot guidance only to matching files or tasks.

**Tie-break**: The rule used when two words have the same count. This workshop uses `StringComparer.Ordinal` ascending.

## Official resources

External links are centralized here so the rest of the workshop docs stay stable.

Last verified: 2026-08-18.

### GitHub Copilot

- GitHub Copilot documentation: https://docs.github.com/copilot
- GitHub Copilot code review in VS Code and GitHub: https://docs.github.com/en/copilot/how-tos/use-copilot-agents/request-a-code-review/use-code-review?tool=vscode
- Repository custom instructions for Copilot: https://docs.github.com/en/copilot/how-tos/copilot-on-github/customize-copilot/add-custom-instructions/add-repository-instructions
- Agent Skills for GitHub Copilot: https://docs.github.com/en/copilot/how-tos/copilot-on-github/customize-copilot/customize-cloud-agent/add-skills
- Configure MCP servers for Copilot cloud agent and code review: https://docs.github.com/en/copilot/how-tos/copilot-on-github/customize-copilot/configure-mcp-servers

### VS Code

- C# in VS Code: https://code.visualstudio.com/docs/csharp/get-started
- Custom instructions in VS Code: https://code.visualstudio.com/docs/agent-customization/custom-instructions
- Agent Skills in VS Code: https://code.visualstudio.com/docs/agent-customization/agent-skills
- MCP servers in VS Code: https://code.visualstudio.com/docs/agent-customization/mcp-servers
- MCP configuration reference in VS Code: https://code.visualstudio.com/docs/agents/reference/mcp-configuration

### .NET and testing

- Install .NET: https://learn.microsoft.com/dotnet/core/install/
- .NET CLI overview: https://learn.microsoft.com/dotnet/core/tools/
- xUnit.net: https://xunit.net/

### Optional editor references

- Visual Studio downloads and .NET workload: https://visualstudio.microsoft.com/downloads/
- JetBrains Rider GitHub Copilot help: https://docs.github.com/en/copilot/concepts/agents/copilot-in-jetbrains

## Version-sensitive notes

- VS Code Agent Skills: official docs currently describe project skills under `.github/skills/`, `.claude/skills/`, or `.agents/skills/`, with each skill in its own folder containing `SKILL.md`. Required frontmatter fields are `name` and `description`.
- VS Code MCP: official docs currently use `.vscode/mcp.json` with a top-level `servers` object. An HTTP server uses `"type": "http"` and `"url": "..."`.
- GitHub repository MCP settings: official GitHub docs currently use a top-level `mcpServers` object and recommend allowlisting specific tools.
- Editor-local Copilot code review in VS Code: official GitHub docs currently describe reviewing selected code with **Generate Code** > **Review**, and reviewing local changes from **Source Control** by hovering over **CHANGES** and selecting **Copilot Code Review - Uncommitted Changes**. UI labels can change, so treat menu text as version-sensitive.
