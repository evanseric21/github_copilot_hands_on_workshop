# Troubleshooting



Start here when setup or a lab blocks you.



## Quick path



1. Re-run the relevant command and read the first error.

2. Compare your path with the README layout.

3. Ask Copilot to explain the error, not to rewrite everything.

4. If blocked for more than two minutes in class, raise your hand.



## .NET SDK not found



Symptoms: `dotnet` is not recognized, or the version is not .NET 10.



- Install or repair the .NET 10 SDK.

- Restart the terminal after installation.

- Run `dotnet --list-sdks`.

- If your machine has policy restrictions, pair with another learner.



## Restore or test fails



Run:



```powershell

dotnet restore .\GitHubCopilotWorkshop.sln

dotnet test .\GitHubCopilotWorkshop.sln

```



If restore is blocked by network policy, do not spend the live session on proxy debugging. Pair with a working machine and continue.



## Copilot is not available in VS Code



- Confirm GitHub Copilot and GitHub Copilot Chat extensions are installed.

- Sign in to GitHub from VS Code.

- Confirm your account has Copilot enabled.

- Reload VS Code after sign-in.



## Agent mode or UI labels differ



Copilot UI changes over time. Use the closest current chat mode or command. The workshop goal is the workflow: give Copilot context, let it propose changes, inspect the diff, run tests, and iterate.



## Scoped instructions do not seem to apply



- Confirm the file ends in `.instructions.md`.

- Confirm it is under `.github/instructions/`.

- Confirm the `applyTo` glob matches the file you are editing, such as `"**/*.cs"`.

- Start a fresh Copilot chat if old context dominates.



## Agent Skill does not load



- Confirm the path is `.github/skills/<name>/SKILL.md`.

- Confirm the folder name and `name` use lowercase letters, numbers, and hyphens.

- Confirm `description` says what the skill does and when to use it.

- Reference any extra files from the `SKILL.md` body.



## MCP demo issues



MCP is optional. If `.vscode/mcp.json.example` does not work in your environment, observe the facilitator demo. Do not add secrets or start untrusted servers.



## Editor-local code review is missing

Use the current VS Code UI if labels have moved. Official GitHub docs currently describe these VS Code paths:

- For a selection: select code, right-click, then choose **Generate Code** > **Review**.
- For local changes: open **Source Control**, hover over **CHANGES**, then click **Copilot Code Review - Uncommitted Changes**.
- If those entry points are unavailable, ask Copilot Chat: "Review this selected C# code for correctness, edge cases, and tests."
- Pull request review is optional and not required for completion.



## Sample output differs



Use the workshop rules: ASCII letter/digit tokens, invariant lowercase, no stop words, count descending, then ordinal tie-break. Run:



```powershell

dotnet run --project .\lab-refactor\WordFrequencyRefactor\WordFrequencyRefactor.csproj -- .\samples\sample.txt --top 5

```



Expected first five lines are listed in [preflight.md](preflight.md).

