# Lab 3 — Reusable C# skill
> Lab 3 of 7 · [⬅️ Previous](../02-scoped-csharp-instructions/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 8 minutes |
| **Copilot surface** | Copilot Chat — Agent mode |
| **Working directory** | Repository root |
| **Starting point** | `labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md` |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Package one repeatable C# procedure — scaffold an xUnit test class the way this repo does it — as an Agent Skill that Copilot loads when its description matches the task.

## Before you start

Lab 0 passed. Lab 2 helps but is not required. The template in this lab folder is a starter; it is not an active skill until you copy it into `.github/skills/`.

Scoped instructions change how Copilot writes. A skill packages a whole procedure Copilot can pull in when it recognizes the job. The description is the trigger.

## Steps

1. Read the template.

   ```text
   # Working directory: repository root
   code labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md
   ```

2. Create the skill folder and copy the template in VS Code Explorer: under `.github`, create `skills/csharp-xunit-test`, then copy `labs/03-reusable-csharp-skill/starter/skill-template/SKILL.md` into it.

   ```text
   # Working directory: repository root
   code .github/skills/csharp-xunit-test/SKILL.md
   ```

3. Fill in `name:` as `csharp-xunit-test` and write a description that says what the skill does and when to use it.

4. Fill in the TODO steps. Keep the body to a short numbered procedure.

5. If you are stuck, replace the file with this finished fallback skill.

   ```markdown
   ---
   name: csharp-xunit-test
   description: Scaffold a new xUnit test class that follows this repository's C# test conventions. Use when adding or expanding tests for a C# class in this repo.
   ---

   # New xUnit test class

   Use these steps whenever someone asks for tests for a C# type in this repository.

   ## Steps

   1. Create `<ClassName>Tests.cs` in the test project that references the project under test.
   2. Use a file-scoped namespace ending in `.Tests`, and mark the class `public sealed`.
   3. Use `[Fact]` for a single case and `[Theory]` with `[InlineData]` when the same assertion runs over several inputs.
   4. Name every test `Method_Scenario_Expected` — for example `TopWords_EmptyText_ReturnsEmptyList`.
   5. Cover, at minimum: the happy path, one boundary or empty input, and one error case.
   6. Do not change production code to make a test pass. Report the failure instead.
   ```

6. Save the file and reload VS Code if the skill does not appear immediately.

7. In Agent mode, send the natural invocation without naming the skill.

   ```text
   I need a new xUnit test class for the WordFrequencyAnalyzer type in this repository.
   Follow whatever conventions this repo defines for test classes.
   ```

8. Ask whether the skill fired.

   ```text
   Did you use an Agent Skill for that answer? Name it, quote its description,
   and list which of its steps you followed.
   ```

9. If it did not fire, use the explicit fallback.

   ```text
   Use the csharp-xunit-test skill in .github/skills/ to scaffold a test class for WordFrequencyAnalyzer.
   ```

## Done when

- [ ] `.github/skills/csharp-xunit-test/SKILL.md` exists.
- [ ] `name:` matches the folder name exactly.
- [ ] `description:` says what the skill does and when to use it.
- [ ] No TODOs remain.
- [ ] Copilot uses the skill or follows it when explicitly invoked.

## Verify

1. Confirm the file and frontmatter.

```text
# Working directory: repository root
git grep --no-index -n "name:" -- .github/skills/csharp-xunit-test/SKILL.md
git grep --no-index -n "description:" -- .github/skills/csharp-xunit-test/SKILL.md
```

2. Confirm no TODOs remain.

```text
# Working directory: repository root
git grep --no-index -n "TODO" -- .github/skills/csharp-xunit-test/SKILL.md
```

If it prints nothing, you have replaced all the TODO placeholders. If lines print, you still have placeholders to fill.

3. Confirm Copilot names `csharp-xunit-test` or the output follows your skill steps.

## If you get stuck

<details>
<summary>Fallback path</summary>

At 4 minutes `SKILL.md` should be saved under `.github/skills/csharp-xunit-test/` with a real description. If not, use the finished fallback skill in step 5 and spend the remaining time seeing it fire.

If you want the full starter and resource example, compare with `labs/03-reusable-csharp-skill/starter/skill-template/`.

| Symptom | Fix |
| --- | --- |
| Copilot ignores the skill | Rewrite the description as `<what it does>. Use when <situation>.` Reload VS Code. |
| `name` does not match the folder | Rename the folder or the frontmatter so both are identical. |
| Nothing loads | Path must be `.github/skills/<name>/SKILL.md`. |
| It fires but output is odd | Add one concrete example line to a step. |
| You want to undo it | Remove the skill folder. |

To undo it, delete `.github/skills/csharp-xunit-test` from VS Code Explorer.

No push or pull request is required. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional skill experiments</summary>

- Bundle and reference `starter/skill-template/resources/xunit-test-class.md` from your skill body.
- Temporarily change the description to `helps with tests`, reload, and watch the natural prompt stop firing.
- Keep the skill for Lab 5; if it is good, it may fire when you ask for tests.

</details>

## Next

➡️ [Lab 4 — MCP literacy](../04-mcp-literacy/README.md)
