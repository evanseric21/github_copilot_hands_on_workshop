# Lab 4 — MCP literacy
> Lab 4 of 7 · [⬅️ Previous](../03-reusable-csharp-skill/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 2.5 minutes — guided by the facilitator |
| **Copilot surface** | Copilot Chat plus editor configuration files, read-only |
| **Working directory** | Repository root |
| **Starting point** | `.vscode/mcp.json.example`, an example with no credentials |
| **Track** | Optional; skipping this does not block Labs 5 and 6 |

## Goal

Leave able to answer three questions: what MCP is, where it is configured, and when you should say no.

## Before you start

Lab 0 passed. You will not connect anything, start a server, enter a token, create `.vscode/mcp.json`, or add credentials. This is a literacy lab.

MCP means Model Context Protocol: a supported way to give Copilot new tools and data sources. Treat enabling a server like adding a dependency.

## Steps

1. Watch the facilitator's read-only demo for about 90 seconds.

2. Open the example config.

   ```bash
   # Working directory: repository root
   cat .vscode/mcp.json.example
   ```

3. Notice three details: the VS Code file uses `servers`, the transport is `http` pointing to localhost, and there are no credentials.

4. Compare that with repository-level GitHub configuration, which uses `mcpServers` and shared allowlisted tools.

5. Ask Copilot for a two-sentence explanation.

   ```text
   In two sentences: what is an MCP server, and what is the difference between a local (command)
   server and a remote (URL) server?
   ```

6. Read these trust rules before moving on: grant least privilege, prefer read-only when enough, review the publisher, never commit secrets, use HTTPS for non-loopback servers, and remember repo-level MCP affects cloud agents and code review.

## Done when

- [ ] You can explain MCP in one sentence without saying "extensions".
- [ ] You can name both configuration locations: editor and repository.
- [ ] You read `.vscode/mcp.json.example` and can name the transport.
- [ ] You did not create `.vscode/mcp.json` or enter credentials.

## Verify

```bash
# Working directory: repository root
test -f .vscode/mcp.json.example && echo example-ok
test -f .vscode/mcp.json && echo "created (not expected)" || echo "none (expected)"
```

Then say: "MCP servers give Copilot new tools and data; I configure them in my editor or at the repo level, and I only enable ones I trust."

## If you get stuck

<details>
<summary>Fallback path</summary>

At 75 seconds the demo should be finished and you should be reading `.vscode/mcp.json.example`. If the demo server fails, skip the demo; the config file and trust rules carry the learning objective.

| Symptom | Fix |
| --- | --- |
| Demo fails | Nothing to fix; inspect the example config. |
| Unsure whether to copy the example | Do not copy it during the workshop. |
| Accidentally created `.vscode/mcp.json` | Delete it. |
| Older docs say Copilot Extensions | MCP is the current path for this scenario. |

```bash
# Working directory: repository root
rm .vscode/mcp.json
```

Nothing is committed, pushed, or reviewed. `.vscode/mcp.json` is ignored. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional at-home follow-up</summary>

- Run `MCP: Add Server` from the VS Code Command Palette and cancel after reading the prompts.
- Compare what a local command server and a remote URL server can access.
- If you administer a repository, check Settings → Copilot → MCP servers.
- Ask Copilot for a 6-item trust checklist and add it to your team's onboarding docs.

</details>

## Next

➡️ [Lab 5 — Build analyzer](../05-build-analyzer/README.md)
