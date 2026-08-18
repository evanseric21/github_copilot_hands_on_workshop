# Lab 3 — checklist

Eight minutes. Working directory is the repository root.

## Setup (0–1 min)

- [ ] Read `starter/skill-template/SKILL.md`.
- [ ] Created `.github/skills/csharp-xunit-test/` and copied the template in.

## Author (1–4 min)

- [ ] `name:` is `csharp-xunit-test` — lowercase, hyphens only, **identical to the folder name**.
- [ ] `description:` says what it does **and when to use it**.
- [ ] Every `TODO` replaced.
- [ ] Body is a numbered procedure of five steps or fewer.
- [ ] Removed the "this is a template" quote block.
- [ ] Saved (and reloaded the window if needed).

## Midpoint gate (4 min)

- [ ] `SKILL.md` saved in `.github/skills/csharp-xunit-test/` with a real description. If not — take the finished skill from `prompts/prompt-cards.md` and move on.

## Invoke (4–7 min)

- [ ] Chat is in **Agent** mode.
- [ ] Sent the natural prompt (without naming the skill).
- [ ] The skill fired — or the explicit prompt (card 4) produced output following my steps.

## Verify (7–8 min)

- [ ] `Test-Path .github/skills/csharp-xunit-test/SKILL.md` → `True`
- [ ] `Select-String -Path .github/skills/csharp-xunit-test/SKILL.md -Pattern "TODO"` → no output
- [ ] Copilot names `csharp-xunit-test` when asked which skill it used.
- [ ] The generated test class follows my naming and attribute steps.

## Done means

A **discoverable** `SKILL.md` that Copilot picks up and applies. The generated class does not need to compile — `WordFrequencyAnalyzer` does not exist on your machine until Lab 5.
