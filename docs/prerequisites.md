# Prerequisites

Install these before the workshop.

## Required

- Git.
- .NET 10 SDK available on your `PATH`.
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

```powershell
git --version
dotnet --version
code --version
```

Then run the full preflight in [preflight.md](preflight.md).

## Editor notes

VS Code is the supported path for live steps, scoped instructions, Agent Skills, MCP inspection, and editor-local Copilot code review.

Visual Studio and Rider can open and run the .NET projects. Their Copilot UI, code review entry points, and MCP support may differ. Use them if you are comfortable translating the VS Code instructions, but facilitators will demonstrate VS Code.

## GitHub permissions

All exercises work without pushing a branch or opening a pull request. Editor-local review is the primary review path. Pull request review is optional if your account, organization, and network allow it.

## MCP

MCP is guided literacy/demo only. The included file is an example, read-only configuration. Do not add credentials, install untrusted servers, or enable tools unless a facilitator explicitly guides the demo.
