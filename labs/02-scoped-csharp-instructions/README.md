# Lab 2 — Scoped C# instructions

⬅️ [Lab 1 — Prompt comparison](../01-prompt-comparison/README.md)

| | |
|---|---|
| **Timebox** | 8 minutes |
| **Copilot surface** | Copilot Chat (Ask or Agent) with a `.cs` file open — inline chat also works |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | The supplied starter file `starter/ScopedInstructionsDemo/InstructionProbe.cs` |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Stop repeating your conventions in every prompt. Write them **once**, in a file scoped to `**/*.cs`, and watch Copilot apply them without being asked.

Lab 1 was per-request context. This is **standing context**: authored once, applied for everyone who clones the repo.

## Prerequisites

- Lab 0 passed.
- The starter project already exists and already builds — **do not modify anything under `starter/`** except when a step tells you to let Copilot edit `InstructionProbe.cs`.

Take ten seconds to look at what you are about to influence:

```powershell
# Working directory: repository root
Get-Content labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs
```

> **bash:** `cat labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs`

## Copilot surface note

Scoped instruction files live at `.github/instructions/<name>.instructions.md`.
The filename **must** end in `.instructions.md`, and the frontmatter key `applyTo` takes a quoted glob. For several extensions, prefer one brace-expansion pattern — `"**/*.{cs,csproj}"` — over a comma-separated list, which is not portable across every Copilot surface.

## Definition of done

- [ ] `.github/instructions/csharp.instructions.md` exists, with valid frontmatter and a quoted `applyTo` glob.
- [ ] It contains 3–5 concrete, checkable C# conventions.
- [ ] A Copilot generation on `InstructionProbe.cs` **visibly** obeys at least two of them.
- [ ] The starter project still builds.

---

## Steps

1. **Create the folder and file.**

   ```powershell
   # Working directory: repository root
   New-Item -ItemType Directory -Force -Path .github/instructions | Out-Null
   New-Item -ItemType File -Force -Path .github/instructions/csharp.instructions.md | Out-Null
   code .github/instructions/csharp.instructions.md
   ```

   > **bash:** `mkdir -p .github/instructions && touch .github/instructions/csharp.instructions.md`

2. **Paste the frontmatter and your rules.** Start from the block in [Copy/paste prompts](#copypaste-prompts) below, or write your own. Keep it to 3–5 rules — always-on context should be short and high-signal.

3. **Save the file.** Nothing applies until it is saved.

4. **Open the starter file** `labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs` in the editor. The glob only matches when Copilot is actually working on a `.cs` file.

5. **Trigger a generation.** With `InstructionProbe.cs` open and focused, send prompt A from [Copy/paste prompts](#copypaste-prompts). Notice that the prompt says nothing about ordering, casing, or style — your instruction file has to carry that.

6. **Read the output against your rules.** Point at the specific lines that came from your file. If nothing came from your file, see the recovery table.

7. **Accept the change** and confirm the project still compiles (see [Verify](#verify)).

## Copy/paste prompts

### The instruction file (paste into `.github/instructions/csharp.instructions.md`)

```markdown
---
applyTo: "**/*.{cs,csproj}"
---

# C# conventions for this workshop repository

- Keep logic out of `Program`/`Main`. Put behaviour in small, pure `static` methods that return a value.
- Use file-scoped namespaces (`namespace Foo;`) and enable nullable reference types.
- Compare, sort, and key strings with `StringComparer.Ordinal`; normalise case with `ToLowerInvariant()`.
- Use `var` only when the type is obvious from the right-hand side; otherwise write the type.
- Tests are xUnit. Use `[Theory]` with `InlineData` when it removes duplication, and name tests
  `Method_Scenario_Expected`.
```

### Prompt A — the trigger (send with `InstructionProbe.cs` open)

```text
Add a method to InstructionProbe that takes an IEnumerable<string> of raw words and returns
a single string listing the distinct words, comma-separated.
```

Deliberately under-specified. Your instruction file should supply the rest: `static`, ordinal ordering, `ToLowerInvariant()`, no logic bleeding into a `Main`.

### Prompt B — ask Copilot to show its work

```text
Which instruction files were applied to your last answer, and which specific rule did each line follow?
```

## Midpoint checkpoint (at 4 minutes)

The file should be **saved with valid frontmatter** and you should be sending prompt A.

If you are still writing rules at 4 minutes, paste the block above verbatim and move on. Authoring your own rule set is the stretch goal, not the lab.

## Verify

**1. The file is where Copilot expects it:**

```powershell
# Working directory: repository root
Test-Path .github/instructions/csharp.instructions.md
Get-Content .github/instructions/csharp.instructions.md -TotalCount 3
```

Expect `True`, then the first three lines: `---`, an `applyTo:` line with a **quoted** glob, `---`.

> **bash:** `test -f .github/instructions/csharp.instructions.md && head -3 .github/instructions/csharp.instructions.md`

**2. The generated code obeys the rules.** Look for at least two of these in the method Copilot just wrote:

| Rule | What you should see |
|---|---|
| Pure static methods | `public static string ...` returning a value, no `Console.WriteLine` |
| Ordinal string handling | `StringComparer.Ordinal` in the `OrderBy`/`Distinct`/dictionary |
| Invariant lowercase | `ToLowerInvariant()` |
| `var` discipline | explicit types where the right-hand side is not obvious |

**3. It still compiles:**

```powershell
# Working directory: repository root
dotnet build labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/ScopedInstructionsDemo.csproj
```

Expect `Build succeeded`.

**4. Copilot admits the source.** Run prompt B and confirm it names `csharp.instructions.md`. In VS Code you can also expand the **References/Used** list on the chat response and see the instruction file listed.

## No-push / no-PR fallback

Everything here is local files on disk. No commit, push, or pull request is required at any point.

If you *want* the safety of a checkpoint, this is entirely local:

```powershell
# Working directory: repository root
git add .github/instructions/csharp.instructions.md
git commit -m "Add scoped C# instructions"
```

No remote needed. If your laptop blocks git entirely, skip it — the instruction file works from the working tree.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| Copilot ignores the rules completely | Check the filename: it must end **`.instructions.md`** and sit in `.github/instructions/`. `csharp-instructions.md` will not work. |
| Frontmatter error / no effect | The glob must be quoted: `applyTo: "**/*.cs"`. The `---` fences must be the very first and third lines, with no blank line above them. |
| Rules apply, but you cannot tell | Your rules are too vague. "Write clean code" is invisible; "use `StringComparer.Ordinal`" is visible in the diff. Swap one vague rule for one mechanical rule. |
| Copilot edited the wrong file | Make sure `InstructionProbe.cs` is the focused editor tab before you send prompt A. |
| You broke the starter and the build fails | Undo with `git restore labs/02-scoped-csharp-instructions/starter` (working directory: repository root), then try again. |
| Out of time | Paste the ready-made instruction block, send prompt A, and read the output. That alone satisfies the definition of done. |

## Stretch (optional, intermediate)

- **Prove the glob.** Open a `.md` file and ask for the same method. The C# rules should *not* apply. That is the difference between scoped instructions and repo-wide `.github/copilot-instructions.md`.
- **Split by scope.** Add a second file `.github/instructions/tests.instructions.md` with `applyTo: "**/*Tests.cs"` holding test-only conventions, and confirm the two stack when Copilot edits a test file.
- **Write a rule you actually disagree with** (e.g. "never use `var`") and watch Copilot follow it. Good demonstration that these files are power tools — a bad rule scales just as well as a good one.
- **Take it home:** the same file, with your team's real conventions, is a five-minute Monday-morning win.

## Reflect (30 seconds)

Which of your rules was *mechanically checkable* and which was just a wish?
Copilot follows the checkable ones far more reliably — and so do humans.

## Next

➡️ [Lab 3 — Reusable C# Agent Skill](../03-reusable-csharp-skill/README.md)
