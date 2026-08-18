# Lab 2 — checklist

Tick as you go. Eight minutes, working directory is the repository root.

## Setup (0–1 min)

- [ ] `labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs` is open in the editor.

## Author (1–4 min)

- [ ] `.github/instructions/` folder exists.
- [ ] File is named exactly `csharp.instructions.md` (ends in `.instructions.md`).
- [ ] Frontmatter opens on line 1 with `---`.
- [ ] `applyTo:` glob is **quoted** — e.g. `applyTo: "**/*.{cs,csproj}"`. Use one brace-expansion pattern rather than a comma-separated list.
- [ ] 3–5 rules, each one mechanically checkable.
- [ ] File saved.

## Midpoint gate (4 min)

- [ ] Instruction file saved and prompt A sent. If not — paste the ready-made block from the README and move on.

## Trigger and read (4–7 min)

- [ ] Prompt A sent with the `.cs` file focused.
- [ ] I can point at **two** lines in the generated code that came from my rules.

## Verify (7–8 min)

- [ ] `Test-Path .github/instructions/csharp.instructions.md` → `True`
- [ ] First three lines are `---`, `applyTo: "..."`, `---`
- [ ] `dotnet build labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/ScopedInstructionsDemo.csproj` → `Build succeeded`
- [ ] Prompt B names `csharp.instructions.md` as an applied instruction file.

## Done means

A saved `*.instructions.md` with a correct `applyTo` glob that **measurably** changed Copilot's suggestion — not just a file that exists.
