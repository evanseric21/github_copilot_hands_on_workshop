# Lab 4 — checklist

Two and a half minutes, guided. Working directory is the repository root.

## Watch (0:00–1:30)

- [ ] Watched the facilitator's read-only MCP demo.
- [ ] Saw where the server's tools appear in the chat tool picker.

## Read (1:30–2:15)

- [ ] Opened `.vscode/mcp.json.example`.
- [ ] Noticed the VS Code key is `servers`; repository-level config on GitHub.com uses `mcpServers`.
- [ ] Noticed the transport is `http` with a URL (the alternative is a local command).
- [ ] Noticed there are **no credentials** in the file.

## Trust rules (2:15–2:30)

- [ ] An MCP server can act on my behalf — adding one is like adding a dependency.
- [ ] Grant the narrowest set of tools that does the job.
- [ ] Repo-level config is shared with the cloud coding agent and code review.
- [ ] Secrets never go in a committed config file.

## Verify

- [ ] `Test-Path .vscode/mcp.json.example` → `True`
- [ ] `Test-Path .vscode/mcp.json` → `False` (I wired nothing)

## Done means

I can explain MCP in one sentence, name both configuration locations, and say when I would refuse to enable a server. No server was connected and no credential was entered.
