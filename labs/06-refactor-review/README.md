# Lab 6 — Refactor review
> Lab 6 of 7 · [⬅️ Previous](../05-build-analyzer/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 19 minutes |
| **Copilot surface** | Agent mode for refactor plus Copilot code review on uncommitted changes |
| **Working directory** | Repository root |
| **Starting point** | `labs/06-refactor-review/starter/` — working code that is not nice to read |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Take code that works but is rough, lock its behavior with tests, clean it up in small moves, request editor-local Copilot code review, and triage findings instead of blindly accepting them. Editor-local means the review happens inside your editor on your uncommitted changes, not on GitHub.

## Before you start

Lab 0 passed. Lab 5 is not required; this lab uses its own starter project. The starter implements the same [frozen contract](../05-build-analyzer/contract.md). Behavior must not change.

## Steps

1. Prove the baseline is green before changing anything.

   ```text
   # Working directory: repository root
   dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
   ```

2. Capture the default output.

   ```text
   # Working directory: repository root
   dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt
   ```

3. Capture the explicit top 5 output.

   ```text
   # Working directory: repository root
   dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt --top 5
   ```

4. Read `WordFrequencyAnalyzer.cs` and `CommandLineApp.cs`. Look for the rough edges: double dictionary lookup, vague variable names, `Run` doing too many jobs, a magic default `10`, and duplicated usage text.

5. Send prompt card 1 from [prompt-cards.md](prompt-cards.md) to add characterization tests for argument handling. Run them against the unrefactored code.

6. Send prompt card 2 to refactor one small move at a time. Suggested moves: extract argument parsing, name the default top count, simplify counting and ordering, rename vague variables, and de-duplicate usage.

7. Re-run tests after every move.

   ```text
   # Working directory: repository root
   dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
   ```

8. Request an editor-local Copilot code review: open the Source Control panel (`Ctrl+Shift+G`), then look for a Copilot code-review action on your uncommitted changes. The exact label varies by Copilot version. If you do not see one, use prompt card 3 for a chat-based review of your diff.

9. Open [review-notes.md](review-notes.md) and record at least two findings. Mark each **Addressed** with what changed or **Dismissed** with why.

10. Run the final tests and sample output.

    ```text
    # Working directory: repository root
    dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
    dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt --top 5
    ```

## Done when

- [ ] Baseline tests passed before you touched code.
- [ ] Counting and argument parsing are in smaller, well-named units.
- [ ] Missing-file handling is still graceful and exits `1`.
- [ ] You requested at least one editor-local Copilot code review or the chat-review fallback.
- [ ] At least two findings are addressed or dismissed with rationale in `review-notes.md`.
- [ ] `dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests` is green with no test weakened or deleted.

## Verify

1. Tests are still green:

```text
# Working directory: repository root
dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
```

2. Behavior is unchanged:

```text
# Working directory: repository root
dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt
dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt --top 5
dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- no-such-file.txt
```

The missing-file command should print an error to stderr and exit non-zero; the graceful failure is the behavior to preserve.

3. There is a real diff and notes were recorded:

```text
# Working directory: repository root
git diff --stat labs/06-refactor-review/starter
git grep --no-index -nE "Addressed|Dismissed" -- labs/06-refactor-review/review-notes.md
```

## If you get stuck

<details>
<summary>Fallback path</summary>

By 9–10 minutes you should have at least one completed refactor move and green tests. If not, do only the argument-parsing extraction and go straight to review. A small reviewed diff beats a big unreviewed refactor.

| Symptom | Fix |
| --- | --- |
| Baseline tests fail | Build the solution, confirm .NET 10, and retry. Never refactor on red. |
| A test goes red mid-refactor | Undo the last move; do not edit the test to pass. |
| Agent rewrote everything | Undo and ask for one move only. |
| Code review entry point is missing | Use prompt card 3 for chat-based review. |
| Review is vague | Review a smaller selection. |
| Zero findings | Ask prompt card 4 for top concerns; if none are actionable, record that rationale. |
| Out of time | Do one extraction, one review request, and one honest note per finding. |

```text
# Working directory: repository root
dotnet build GitHubCopilotWorkshop.sln
git restore labs/06-refactor-review/starter
```

No push or pull request is required. Optional PR review is enrichment only. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional review and refactor practice</summary>

- Reduce allocations in `TopWords` without changing behavior.
- Replace repeated `[Fact]` tests with a `[Theory]`.
- Ask Copilot to review once for correctness and once for readability; compare results.
- Add a test for an undefined behavior, document the decision, then implement it.
- If you have push rights and time, open a PR and compare PR review with editor-local review.

</details>

## You're done — what next?

You completed the workshop loop: prompt, customize, build, test, refactor, review, and decide. Keep learning with [docs/reference.md](../../docs/reference.md), and try one Monday-sized habit: add a real `.github/instructions/*.instructions.md` file to a repository your team already uses.
