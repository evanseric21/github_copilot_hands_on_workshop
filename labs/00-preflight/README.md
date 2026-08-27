# Lab 0 — Preflight
> Lab 0 of 7 · [⬅️ Previous](../../README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 10–15 min before class, plus a **2-minute in-session gate** |
| **Copilot surface** | Copilot Chat, agent mode, model picker, editor-local Copilot code review entry point |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | A cloned copy of this repository and a terminal |
| **Track** | Everyone. Later labs assume this passed. |

## Goal

Prove that your machine can build C#, run tests, and talk to Copilot before the room starts moving.

## Before you start

Install the pre-arrival tools in [docs/setup.md](../../docs/setup.md): VS Code, GitHub Copilot and Copilot Chat, .NET SDK 10, git, terminal access, and network access for clone/restore/sign-in. VS Code will offer the recommended extensions from `.vscode/extensions.json`; say yes.

## Steps

1. Clone the repository and open it.

   ```text
   # Working directory: wherever you keep code
   git clone https://github.com/evanseric21/github_copilot_hands_on_workshop.git
   cd github_copilot_hands_on_workshop
   code .
   ```

2. Confirm the SDK.

   ```text
   # Working directory: repository root
   dotnet --version
   ```

3. Warm the build before the session.

   ```text
   # Working directory: repository root
   dotnet build GitHubCopilotWorkshop.sln
   ```

4. Run the preflight app.

   ```text
   # Working directory: repository root
   dotnet run --project labs/00-preflight/starter/Preflight
   ```

   Expected output:

   ```text
   .NET 10 preflight passed
   ```

5. Run the preflight test.

   ```text
   # Working directory: repository root
   dotnet test labs/00-preflight/starter/Preflight.Tests/Preflight.Tests.csproj
   ```

6. Open Copilot Chat in VS Code, switch to Agent mode, and send:

   ```text
   In one sentence, what target framework does labs/00-preflight/starter/Preflight/Preflight.csproj use?
   ```

7. Find the editor-local review entry point in VS Code: Source Control → **Copilot Code Review – Uncommitted Changes**. Do not run a review yet.

## Done when

- [ ] `dotnet --version` reports a 10.x SDK.
- [ ] The solution restores and builds.
- [ ] The preflight app prints `.NET 10 preflight passed`.
- [ ] The preflight test passes.
- [ ] Copilot Chat answers in Agent mode.
- [ ] You can find the editor-local Copilot code review entry point.

## Verify

```text
# Working directory: repository root
dotnet run --project labs/00-preflight/starter/Preflight
dotnet test labs/00-preflight/starter/Preflight.Tests/Preflight.Tests.csproj
```

Green on both lines clears you for the rest of the workshop.

## If you get stuck

<details>
<summary>Recovery path</summary>

After step 4 you should have a green build and the line `.NET 10 preflight passed`. If not, stop and recover before continuing.

| Symptom | Fix |
| --- | --- |
| `dotnet` is not recognized | Install the .NET 10 SDK, then open a new terminal. |
| Version shows 8.x or 9.x | Install .NET 10 side-by-side; these projects target `net10.0`. |
| Restore hangs or fails | Retry once on another network; if blocked, pair with someone restored. |
| Copilot is not signed in | Use Command Palette → `GitHub Copilot: Sign In`. |
| No Agent mode | Update GitHub Copilot Chat and reload VS Code. |

This lab needs read-only network access for clone and restore only. No push or pull request is required anywhere in the workshop. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional checks</summary>

Run the whole suite:

```text
# Working directory: repository root
dotnet test GitHubCopilotWorkshop.sln
```

Peek at [samples/sample.txt](../../samples/sample.txt). Then ask Copilot Chat:

```text
Summarize what labs/06-refactor-review/starter/WordFrequencyRefactor/CommandLineApp.cs does in five bullets.
```

</details>

## Next

➡️ [Lab 1 — Prompt comparison](../01-prompt-comparison/README.md)
