# Lab 4 — MCP literacy (guided, read-only)

⬅️ [Lab 3 — Reusable C# Agent Skill](../03-reusable-csharp-skill/README.md)

| | |
|---|---|
| **Timebox** | 2.5 minutes — guided by the facilitator |
| **Copilot surface** | Copilot Chat + editor configuration files (**read-only**) |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | [`.vscode/mcp.json.example`](../../.vscode/mcp.json.example) — an example config with no credentials |
| **Track** | Optional. Skipping this lab costs you nothing in Labs 5 and 6. |

> ⚠️ **You will not connect anything in this lab.** No servers are started, no tokens are entered, no `mcp.json` is created.
> This is literacy: know what MCP is, know where it is configured, know how to judge whether to trust one.
> Wiring an MCP server on a corporate laptop is a decision for your security team, not a 2-minute workshop exercise.

## Goal

Leave able to answer three questions:

1. **What is MCP?** The Model Context Protocol — the supported way to give Copilot new tools and data sources. If you find older "Copilot Extensions" documentation, it now routes here.
2. **Where is it configured?** In VS Code via the `MCP: Add Server` command or `.vscode/mcp.json`; on GitHub.com under repository **Settings → Copilot → MCP servers**.
3. **When should I say yes?** Only for a server you trust, granting only the tools you actually need.

## Prerequisites

- Lab 0 passed. Nothing else — no accounts, no tokens, no network calls.

## Definition of done

- [ ] You can explain MCP in one sentence without saying "extensions".
- [ ] You have read the example config and can name the transport it uses.
- [ ] You can state the two configuration locations (editor and repository).
- [ ] You have **not** created `.vscode/mcp.json`.

---

## Steps

1. **Watch the facilitator demo** (~90 seconds). You will see a read-only server exposed as tools in the chat tool picker, one call made, and the result appear in the conversation. Hands off keyboards for this part.

2. **Open the example config** — reading only:

   ```powershell
   # Working directory: repository root
   Get-Content .vscode/mcp.json.example
   ```

   > **bash:** `cat .vscode/mcp.json.example`

   ```json
   {
     "servers": {
       "readOnlyWorkshopDemo": {
         "type": "http",
         "url": "http://localhost:3999/mcp"
       }
     }
   }
   ```

   Three things to notice: the VS Code file keys off **`servers`**; the transport here is **`http`** pointing at a URL (the alternative is a local command); and there are **no credentials anywhere in the file**. Secrets never belong in a config you commit.

   > **On `http://` vs `https://`:** plaintext `http` is acceptable here **only** because the URL is loopback (`localhost`) and the server is a throwaway local demo. Any MCP server reached over a network — anything that is not `localhost`/`127.0.0.1` — must use `https://`, otherwise the tool calls and their results travel in the clear.

3. **Note the schema difference.** VS Code's `.vscode/mcp.json` uses a `servers` object. Repository-level configuration on GitHub.com uses an `mcpServers` object, where each server declares its type and the tools it is allowed to use. Same idea, different key — this trips people up when copying snippets between the two.

4. **Ask Copilot one question** (Ask mode is fine):

   ```text
   In two sentences: what is an MCP server, and what is the difference between a local (command)
   server and a remote (URL) server?
   ```

5. **Read the trust rules** below.

## The trust rules

- An MCP server can act **on your behalf**. Treat adding one exactly like adding a dependency to your build.
- Grant the **narrowest set of tools** that does the job. "All tools" is not a default, it is a decision.
- Review who publishes a server before enabling it. Prefer read-only servers when read-only will do.
- Repository-level MCP configuration is shared with the cloud coding agent and Copilot code review, so one careless entry has a wide blast radius.
- Never put a token, key, or password into a config file that gets committed. Use your editor's secret prompt / input mechanism instead.
- Use `https://` for any remote server. Plaintext `http://` is only defensible for a loopback (`localhost`) server on your own machine.

## Copy/paste prompt

```text
I am evaluating an MCP server before enabling it in my repository.
Give me a 6-item checklist for deciding whether to trust it, focused on
least-privilege tool selection, credential handling, and blast radius.
Keep it to one line per item.
```

## Midpoint checkpoint (at 75 seconds)

The demo should be finished and you should be reading `.vscode/mcp.json.example`.
If the demo server is not cooperating, the facilitator moves straight to step 2 — the config file and the trust rules carry the entire learning objective on their own.

## Verify

```powershell
# Working directory: repository root
Test-Path .vscode/mcp.json.example   # expect True  — the example ships with the repo
Test-Path .vscode/mcp.json           # expect False — you created nothing
```

> **bash:** `test -f .vscode/mcp.json.example && echo example-ok; test -f .vscode/mcp.json && echo "created (not expected)" || echo "none (expected)"`

Then say the sentence out loud: *"MCP servers give Copilot new tools and data; I configure them in my editor or at the repo level, and I only enable ones I trust."* That is the whole lab.

## No-push / no-PR fallback

Nothing is created, committed, pushed, or reviewed in this lab. There is no git involvement at all.
`.vscode/mcp.json` is already listed in `.gitignore`, so even if you experiment later, a local config cannot be committed by accident.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| The facilitator demo fails or no server is available | Nothing to fix. Read the example config and the trust rules — the definition of done does not require a live server. |
| "Should I copy the example to `.vscode/mcp.json`?" | **No.** Not during the workshop. It points at `localhost:3999`, which is not running on your machine, and wiring servers is out of scope. |
| You accidentally created `.vscode/mcp.json` | Delete it: `Remove-Item .vscode/mcp.json` (bash: `rm .vscode/mcp.json`) from the repository root. |
| You were told to use "Copilot Extensions" | That documentation now redirects to MCP. MCP is the current path — you are in the right place. |
| Lost 30 seconds and the room is moving on | Move on. This lab is optional by design and nothing in Labs 5 or 6 depends on it. |

## Stretch (optional, intermediate — do this at home, not now)

- On your own machine, run `MCP: Add Server` from the VS Code Command Palette and read what it asks for before you cancel it. Knowing the prompts is half the literacy.
- Compare a local (command) server with a remote (URL) server: what would each have access to on your laptop?
- Look at your own repository's **Settings → Copilot → MCP servers** page (if you are an admin) and check whether anything is already configured.
- Write the six-item trust checklist from the prompt above into your team's onboarding doc. That is a genuinely useful artefact and it takes ten minutes.

## Reflect (30 seconds)

Which of the trust rules would your current team most likely skip in a hurry?
That one is worth writing down before anyone in your org enables their first server.

## Next

➡️ [Lab 5 — Build the analyzer](../05-build-analyzer/README.md) — the capstone. Hands on keyboards.
