# Lab 5 — Build analyzer
> Lab 5 of 7 · [⬅️ Previous](../04-mcp-literacy/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 27 minutes |
| **Copilot surface** | Copilot Chat — Agent mode |
| **Working directory** | Repository root |
| **Starting point** | `labs/05-build-analyzer/work/` (intentionally empty except `.gitkeep`) |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Go from an empty work folder to a tested C# CLI that prints the most frequent words in a text file, verified by `dotnet test` and matching the frozen behavior contract.

## Before you start

Lab 0 passed. Read [contract.md](contract.md) first. The contract is frozen: tokenization, ordering, CLI shape, default `--top 10`, and exit codes are not up to you or Copilot. Lab 2 instructions and the Lab 3 skill can stay active.

## Steps

1. Scaffold the projects by minute 4.

   ```bash
   # Working directory: repository root
   dotnet new console -n WordFrequency -o labs/05-build-analyzer/work/WordFrequency
   dotnet new xunit -n WordFrequency.Tests -o labs/05-build-analyzer/work/WordFrequency.Tests
   dotnet reference add labs/05-build-analyzer/work/WordFrequency/WordFrequency.csproj --project labs/05-build-analyzer/work/WordFrequency.Tests/WordFrequency.Tests.csproj
   ```

2. Send prompt card 1 from [prompt-cards.md](prompt-cards.md) to implement the pure core logic. Do not paraphrase it; it carries the contract.

3. Read the diff before accepting. Look for `TopWords(string text, int top)`, `[A-Za-z0-9]+`, `ToLowerInvariant()`, `StringComparer.Ordinal`, and no file I/O.

4. Send prompt card 2 to add tests by minute 14.

5. Run the tests even if they are red.

   ```bash
   # Working directory: repository root
   dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
   ```

6. Send prompt card 3 to wire the CLI. Keep `Main` thin; argument parsing and output should be testable.

7. Run the shared sample by minute 25.

   ```bash
   # Working directory: repository root
   dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 5
   ```

8. Feed failures back with prompt card 4 until green. If tests are not running by minute 14, switch to prompt card 5, the single rescue prompt. If tokenization or tie-breaks are wrong, use prompt card 6.

## Done when

- [ ] `dotnet test` on your test project is green with at least 5 meaningful tests, including missing-file and empty-input cases.
- [ ] `dotnet run ... -- samples/sample.txt --top 5` prints the pinned five lines.
- [ ] Omitting `--top` prints 10 lines.
- [ ] A missing file exits with code `1` and a clear stderr message.
- [ ] Bad arguments exit with code `2`.
- [ ] Counting logic lives in a pure `TopWords` method, not in `Main`.

## Verify

1. Exact top 5 output:

```bash
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 5
```

```text
tests: 5
build: 3
code: 3
copilot: 3
practice: 3
```

2. Default top 10 output:

```bash
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt
```

```text
tests: 5
build: 3
code: 3
copilot: 3
practice: 3
review: 3
and: 2
lab: 2
proves: 2
the: 2
```

3. Tests are green:

```bash
# Working directory: repository root
dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
```

4. Exit codes match the contract:

```bash
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- no-such-file.txt
echo $?
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top zero
echo $?
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- --help
echo $?
```

## If you get stuck

<details>
<summary>Fallback path</summary>

By 13–14 minutes tests should execute, passing or failing. If they do not, send prompt card 5. The facilitator will call time at 10 and 20 minutes.

| Time | Symptom | Fix |
| --- | --- | --- |
| any | Scaffold commands fail | Confirm repository root and .NET 10; rerun the exact scaffold block. |
| any | `review: 3` appears in top 5 | Tie-break is wrong; use prompt card 6 or tell Copilot to use `StringComparer.Ordinal`. |
| any | Counts are high or punctuation sticks | Tokenizer must match `[A-Za-z0-9]+`, not split on whitespace. |
| any | Agent edited outside `work/` | Inspect and restore unintended paths. |
| any | `dotnet test` finds no tests | Re-run the project reference command. |
| 14 min | Nothing runs | Send prompt card 5. |
| 20 min | Still stuck | Read the working starter in `labs/06-refactor-review/starter/` to understand the shape, then adapt your work. |

```bash
# Working directory: repository root
git status
git restore <path-you-did-not-intend-to-change>
```

No push or pull request is required. Your files on disk are the deliverable. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional enhancements after green</summary>

- Add `--top all`.
- Read from stdin when no path is given.
- Add optional `--ignore` stop words with a test proving default behavior is unchanged.
- Replace repeated `[Fact]` tests with a `[Theory]` without losing cases.
- Benchmark a large file and reduce allocations without changing observable behavior.

</details>

## Next

➡️ [Lab 6 — Refactor review](../06-refactor-review/README.md)
