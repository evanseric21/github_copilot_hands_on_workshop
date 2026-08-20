# Lab 2 — Scoped C# instructions
> Lab 2 of 7 · [⬅️ Previous](../01-prompt-comparison/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 8 minutes |
| **Copilot surface** | Copilot Chat with a `.cs` file open; Ask, Agent, or inline chat |
| **Working directory** | Repository root |
| **Starting point** | `labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs` |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Stop repeating conventions in every prompt. Write them once in `.github/instructions/csharp.instructions.md`, scoped to C# files, and watch Copilot apply them without being asked.

## Before you start

Lab 0 passed. The starter project already builds. Do not modify anything under `starter/` except the generated edit to `InstructionProbe.cs`.

Scoped instruction files live at `.github/instructions/<name>.instructions.md`. The filename must end in `.instructions.md`, and the frontmatter key `applyTo` should use a quoted glob such as `"**/*.{cs,csproj}"`.

## Steps

1. Open the starter file so Copilot has a matching `.cs` file in focus.

   ```bash
   # Working directory: repository root
   code labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs
   ```

2. Create the instruction file.

   ```bash
   # Working directory: repository root
   mkdir -p .github/instructions
   touch .github/instructions/csharp.instructions.md
   code .github/instructions/csharp.instructions.md
   ```

3. Paste this instruction file and save it.

   ```markdown
   ---
   applyTo: "**/*.{cs,csproj}"
   ---

   # C# conventions for this workshop repository

   - Keep logic out of `Program`/`Main`. Put behavior in small, pure `static` methods that return a value.
   - Use file-scoped namespaces (`namespace Foo;`) and enable nullable reference types.
   - Compare, sort, and key strings with `StringComparer.Ordinal`; normalize case with `ToLowerInvariant()`.
   - Use `var` only when the type is obvious from the right-hand side; otherwise write the type.
   - Tests are xUnit. Use `[Theory]` with `InlineData` when it removes duplication, and name tests `Method_Scenario_Expected`.
   ```

4. Return focus to `InstructionProbe.cs` and send this prompt.

   ```text
   Add a method to InstructionProbe that takes an IEnumerable<string> of raw words and returns
   a single string listing the distinct words, comma-separated.
   ```

5. Read the output against your rules. Look for `static`, `ToLowerInvariant()`, ordinal ordering, and no console work.

6. Ask Copilot to show which instructions were applied.

   ```text
   Which instruction files were applied to your last answer, and which specific rule did each line follow?
   ```

7. Accept the change only if it follows at least two rules.

## Done when

- [ ] `.github/instructions/csharp.instructions.md` exists with valid frontmatter and a quoted `applyTo` glob.
- [ ] It contains 3–5 concrete, checkable C# conventions.
- [ ] A Copilot generation on `InstructionProbe.cs` visibly obeys at least two rules.
- [ ] The starter project still builds.

## Verify

1. Confirm the file shape.

```bash
# Working directory: repository root
test -f .github/instructions/csharp.instructions.md && head -3 .github/instructions/csharp.instructions.md
```

2. Build the starter project.

```bash
# Working directory: repository root
dotnet build labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/ScopedInstructionsDemo.csproj
```

3. Confirm Copilot names `csharp.instructions.md` in the applied instruction response.

## If you get stuck

<details>
<summary>Fallback path</summary>

At 4 minutes the instruction file should be saved and the trigger prompt should be sent. If not, paste the provided block exactly and move on.

| Symptom | Fix |
| --- | --- |
| Copilot ignores the rules | Confirm the file ends in `.instructions.md` and sits under `.github/instructions/`. |
| Frontmatter has no effect | The `---` fences must be lines 1 and 3; quote the glob. |
| Rules apply but are invisible | Replace vague rules with mechanical ones such as `StringComparer.Ordinal`. |
| Copilot edits the wrong file | Focus `InstructionProbe.cs` before sending the prompt. |
| Starter build fails | Restore the starter and retry. |

```bash
# Working directory: repository root
git restore labs/02-scoped-csharp-instructions/starter
```

No commit, push, or pull request is required. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional scoped-instruction experiments</summary>

- Open a Markdown file and ask for the same helper as a fenced C# snippet; the C# rules should not apply.
- Add `.github/instructions/tests.instructions.md` with `applyTo: "**/*Tests.cs"` and confirm the two instruction files stack.
- Write one rule your team would actually enforce on Monday.

</details>

## Next

➡️ [Lab 3 — Reusable C# skill](../03-reusable-csharp-skill/README.md)
