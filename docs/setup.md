# Setup

Install these before the workshop. Lab 0 is the authoritative in-session preflight; this page is the pre-arrival checklist.

## Required tools

- Git.
- .NET 10 SDK available on your `PATH`; all projects target `net10.0`.
- VS Code, the primary workshop editor.
- VS Code extensions:
  - GitHub Copilot
  - GitHub Copilot Chat
  - C# Dev Kit
  - C#
- A GitHub account with GitHub Copilot enabled.
- Terminal access that can run `git` and `dotnet`.
- Network access for initial clone, package restore, and Copilot sign-in.

## Verify locally

```bash
# Working directory: anywhere
git --version
dotnet --version
code --version
```

`dotnet --version` must report a 10.x SDK. If multiple SDKs are installed, this can help:

```bash
# Working directory: anywhere
dotnet --list-sdks
```

## Clone and open

```bash
# Working directory: wherever you keep code
git clone https://github.com/evanseric21/github_copilot_hands_on_workshop.git
cd github_copilot_hands_on_workshop
code .
```

If you already cloned the repo, update it before class.

```bash
# Working directory: repository root
git pull
```

## Confirm VS Code and Copilot

1. Accept the recommended extensions from `.vscode/extensions.json`.
2. Confirm Copilot Chat opens and is signed in.
3. Confirm Ask, Plan, and Agent modes or their current equivalents are available.
4. Confirm the model picker opens.

## Warm restore and tests

```bash
# Working directory: repository root
dotnet test labs/00-preflight/starter/Preflight.Tests/Preflight.Tests.csproj
dotnet test GitHubCopilotWorkshop.sln
```

The preflight project should pass with `.NET 10 preflight passed`. The full solution validates the provided starter and refactor projects.

## Editor notes

VS Code is the supported path for live steps, scoped instructions, Agent Skills, MCP inspection, and editor-local Copilot code review. Visual Studio and Rider can open and run the .NET projects, but their Copilot UI, review entry points, and MCP support may differ.

## GitHub permissions

All exercises work without pushing a branch or opening a pull request. Editor-local review is the primary review path. Pull request review is optional enrichment if your account, organization, and network allow it.

## MCP

MCP is guided literacy/demo only. The included file is read-only example configuration. Do not add credentials, install untrusted servers, or enable tools unless a facilitator explicitly guides the demo.

## If setup fails

Use [troubleshooting.md](troubleshooting.md), then ask a facilitator. During the live session, do not spend more than two minutes stuck before raising your hand.
