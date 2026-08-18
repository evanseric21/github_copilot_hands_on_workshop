# Lab 3 — prompt cards (beginner fallback)

Copy, paste, run. Using these is the fallback track, not cheating.

---

## Card 1 — a complete, working `SKILL.md`

Save as `.github/skills/csharp-xunit-test/SKILL.md` (working directory: repository root).
Note the folder name and the `name:` value are identical — that is mandatory.

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
3. Use `[Fact]` for a single case and `[Theory]` with `[InlineData]` when the same assertion runs
   over several inputs.
4. Name every test `Method_Scenario_Expected` — for example `TopWords_EmptyText_ReturnsEmptyList`.
5. Cover, at minimum: the happy path, one boundary or empty input, and one error case.
6. Do not change production code to make a test pass. Report the failure instead.

## Example

    namespace WordFrequencyRefactor.Tests;

    public sealed class WordFrequencyAnalyzerTests
    {
        [Fact]
        public void TopWords_EmptyText_ReturnsEmptyList()
        {
            Assert.Empty(WordFrequencyAnalyzer.TopWords(string.Empty, 5));
        }
    }
```

---

## Card 2 — natural invocation (agent mode)

Deliberately does not name the skill. If it fires, your description did its job.

```text
I need a new xUnit test class for the WordFrequencyAnalyzer type in this repository.
Follow whatever conventions this repo defines for test classes.
```

---

## Card 3 — did the skill fire?

```text
Did you use an Agent Skill for that answer? Name it, quote its description,
and list which of its steps you followed.
```

---

## Card 4 — explicit invocation (when card 2 does not trigger it)

```text
Use the csharp-xunit-test skill in .github/skills/ to scaffold a test class for WordFrequencyAnalyzer.
```

---

## Card 5 — sharpen a description that never fires

```text
Here is my skill description:

"<paste yours>"

Rewrite it in under 200 characters so an agent can tell exactly when to load it.
It must state what the skill does AND the situation that should trigger it.
Return three options.
```

---

## Card 6 — stretch: the A/B test

Temporarily change your description to something vague, reload the window, and run card 2 again:

```markdown
description: helps with tests
```

It should stop firing. Restore the sharp description and watch it come back. Sixty seconds, and you will never write a lazy skill description again.
