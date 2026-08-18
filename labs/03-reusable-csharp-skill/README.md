# Lab 3 — Reusable C# Agent Skill

⬅️ [Lab 2 — Scoped C# instructions](../02-scoped-csharp-instructions/README.md)

| | |
|---|---|
| **Timebox** | 8 minutes |
| **Copilot surface** | Copilot Chat — **Agent** mode |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | [`starter/skill-template/SKILL.md`](starter/skill-template/SKILL.md) — a fill-in-the-blanks template |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Package one repeatable C# procedure — "scaffold an xUnit test class the way this repo does it" — as an **Agent Skill** that Copilot loads on its own when it becomes relevant.

Lab 2 changed *how* Copilot writes. A skill packages *a whole procedure* Copilot can pull in when it recognises the job.

| | Scoped instructions (Lab 2) | Agent Skill (Lab 3) |
|---|---|---|
| Lives at | `.github/instructions/*.instructions.md` | `.github/skills/<name>/SKILL.md` |
| Loads when | a matching file is in play (`applyTo` glob) | the **description** matches what you asked for |
| Contains | standing rules | steps, examples, bundled resources |

That second row is the whole lab: **the description is the trigger.** A vague description means the skill is never used.

## Prerequisites

- Lab 0 passed. Lab 2 helps but is not required.
- The template in this lab folder is a **starter, not a solution** — it has TODOs you must fill in. It sits under `labs/`, so it is *not* an active skill until you copy it into `.github/skills/`.

## Definition of done

- [ ] `.github/skills/csharp-xunit-test/SKILL.md` exists.
- [ ] `name:` uses lowercase letters/hyphens only and **matches the folder name exactly**.
- [ ] `description:` says what the skill does **and when to use it**.
- [ ] The body is a short numbered procedure — not prose.
- [ ] Copilot picks the skill up and produces a test class that follows your steps.

---

## Steps

1. **Read the template** (30 seconds — it is short):

   ```powershell
   # Working directory: repository root
   Get-Content labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md
   ```

   > **bash:** `cat labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md`

2. **Create the skill folder and copy the template in.** The folder name becomes the skill name, so get it right now:

   ```powershell
   # Working directory: repository root
   New-Item -ItemType Directory -Force -Path .github/skills/csharp-xunit-test | Out-Null
   Copy-Item labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md .github/skills/csharp-xunit-test/SKILL.md
   code .github/skills/csharp-xunit-test/SKILL.md
   ```

   > **bash:**
   > `mkdir -p .github/skills/csharp-xunit-test`
   > `cp labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md .github/skills/csharp-xunit-test/SKILL.md`

3. **Fill in the `description`.** Write it as a *trigger*: what it does **and when to use it**. This is the only thing Copilot reads while deciding whether your skill is relevant.

4. **Fill in the TODO steps in the body.** Keep it to five steps or fewer. One convention done well beats an ambitious half-finished skill.

5. **Save**, then **reload the window** if your editor does not pick up new skills immediately (Command Palette → `Developer: Reload Window`).

6. **Invoke it.** Switch chat to **Agent** mode and send prompt A from [Copy/paste prompts](#copypaste-prompts). Do **not** mention the skill by name — the point is that the description earns the invocation.

7. **Check the output against your own steps.** If Copilot ignored the skill, sharpen the description (see recovery table) rather than the body.

## Copy/paste prompts

### Prompt A — the natural invocation (agent mode)

```text
I need a new xUnit test class for the WordFrequencyAnalyzer type in this repository.
Follow whatever conventions this repo defines for test classes.
```

### Prompt B — did the skill fire?

```text
Did you use an Agent Skill for that answer? Name it, quote its description,
and list which of its steps you followed.
```

### Prompt C — the explicit fallback

If prompt A does not trigger the skill, be direct — this still proves the skill body works:

```text
Use the csharp-xunit-test skill in .github/skills/ to scaffold a test class for WordFrequencyAnalyzer.
```

## Midpoint checkpoint (at 4 minutes)

`SKILL.md` should be **saved in `.github/skills/csharp-xunit-test/`** with a real description.

If you are still wordsmithing the body at 4 minutes, take the finished version from [`prompts/prompt-cards.md`](prompts/prompt-cards.md), save it, and spend your remaining time on step 6 — seeing it fire is the payoff.

## Verify

**1. It is in the right place with the right name:**

```powershell
# Working directory: repository root
Test-Path .github/skills/csharp-xunit-test/SKILL.md
Get-Content .github/skills/csharp-xunit-test/SKILL.md -TotalCount 5
```

Expect `True`, then frontmatter whose `name:` is exactly `csharp-xunit-test` — identical to the folder name.

> **bash:** `test -f .github/skills/csharp-xunit-test/SKILL.md && head -5 .github/skills/csharp-xunit-test/SKILL.md`

**2. There are no TODOs left:**

```powershell
# Working directory: repository root
Select-String -Path .github/skills/csharp-xunit-test/SKILL.md -Pattern "TODO"
```

Expect **no output**. Any hit means an unfilled blank.

> **bash:** `grep -n "TODO" .github/skills/csharp-xunit-test/SKILL.md || echo "clean"`

**3. Copilot actually used it:** run prompt B and confirm it names `csharp-xunit-test` and echoes your steps.

**4. The output matches your procedure:** the generated class should use the file name, `[Fact]`/`[Theory]`, and the test-naming convention your body specifies. You are grading Copilot against *your* document — that is the skill working.

> You do **not** need the generated test class to compile in this lab. There is no `WordFrequencyAnalyzer` on your machine yet — you build it in Lab 5. Delete the scaffold afterwards or leave it; nothing depends on it.

## No-push / no-PR fallback

Skills are plain files in the working tree — they work with no remote, no commit, and no pull request.
A skill only needs to be *pushed* when you want teammates to get it, which is a Monday-morning problem, not a workshop one.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| Copilot ignores the skill | Nine times out of ten the description is the problem. Rewrite it as `<what it does>. Use when <the situation>.` and reload the window. |
| `name` does not match the folder | The `name:` value and the directory name must be identical, lowercase letters/numbers/hyphens only. Rename the folder rather than the value if you prefer. |
| Nothing loads at all | Path must be `.github/skills/<name>/SKILL.md` — capitalised `SKILL.md`, inside its own folder. A loose `.github/skills/mine.md` is not a skill. |
| You are out of time | Copy the complete skill from [`prompts/prompt-cards.md`](prompts/prompt-cards.md), save, and run prompt C. Seeing it fire once is the learning objective. |
| It fired but produced something odd | Your body is ambiguous. Add one concrete example line to a step — examples beat adjectives. |
| You want to undo everything | `Remove-Item -Recurse .github/skills/csharp-xunit-test` (bash: `rm -rf .github/skills/csharp-xunit-test`) from the repository root. |

## Stretch (optional, intermediate)

- **Bundle a resource.** Link [`starter/skill-template/resources/xunit-test-class.md`](starter/skill-template/resources/xunit-test-class.md) from your skill body and copy it alongside `SKILL.md`. Copilot only opens bundled files when a step actually references them — that is progressive disclosure, and it is why skills stay cheap.
- **A/B the description.** Save a deliberately vague version ("helps with tests"), reload, run prompt A, and watch it *not* fire. Restore the sharp version. This is the most convincing 60 seconds in the whole lab.
- **Write a second skill for a convention your own team argues about** — CLI flag documentation, error-message format, logging shape. Skills are worth writing exactly where humans keep forgetting.
- **Keep it for Lab 5.** If your skill is good, it will fire on its own when you ask agent mode for tests in the capstone. That is not a coincidence — that is the point.

## Reflect (30 seconds)

Read your description out loud. Does it say **when** to use the skill, or only **what** it does?
Descriptions that only say *what* are the number-one reason skills sit unused in real repositories.

## Next

➡️ [Lab 4 — MCP literacy](../04-mcp-literacy/README.md)
