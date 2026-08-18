# Lab 2 — prompt cards (beginner fallback)

Everything you need to finish Lab 2 in four minutes. Copy, paste, run.

---

## Card 1 — the instruction file

Save as `.github/instructions/csharp.instructions.md` (working directory: repository root).

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

The frontmatter is the part people get wrong. Three things must be true:

1. The filename ends in `.instructions.md`.
2. `---` is line 1 — nothing above it, not even a blank line.
3. The glob is quoted.

---

## Card 2 — the trigger prompt

Open `labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo/InstructionProbe.cs`, make sure it is the focused tab, then send:

```text
Add a method to InstructionProbe that takes an IEnumerable<string> of raw words and returns
a single string listing the distinct words, comma-separated.
```

Notice what this prompt does **not** say: nothing about casing, ordering, purity, or style. If the answer still comes back ordinal-sorted, lowercased and `static`, that came from your instruction file.

---

## Card 3 — make Copilot show its work

```text
Which instruction files were applied to your last answer, and which specific rule did each line follow?
```

---

## Card 4 — if the rules are not landing

Use this to force the comparison and see the delta immediately:

```text
Rewrite the method you just added so that it violates every rule in
.github/instructions/csharp.instructions.md, then show the two versions side by side
and list which rule each difference corresponds to. Do not save the violating version.
```

---

## Card 5 — stretch: prove the glob is doing the work

Open any `.md` file in the repository, focus it, and send:

```text
Write the same distinct-words helper here as a fenced C# snippet.
```

The `**/*.cs` glob does not match a Markdown file, so your C# rules should not apply. That contrast is the entire value of *scoped* instructions versus a repo-wide `.github/copilot-instructions.md`.
