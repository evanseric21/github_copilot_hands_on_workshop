# Lab 5 — checklist

27 minutes. Working directory is the repository root for every command.
Times are targets, not rules — but if you are two boxes behind the clock, jump to the fallback prompt.

## Before you start

- [ ] Read [`contract.md`](contract.md).
- [ ] `dotnet --version` shows 10.x.

## Scaffold (0–4 min)

- [ ] `dotnet new console -n WordFrequency -o labs/05-build-analyzer/work/WordFrequency`
- [ ] `dotnet new xunit -n WordFrequency.Tests -o labs/05-build-analyzer/work/WordFrequency.Tests`
- [ ] `dotnet reference add ... --project ...` succeeded
- [ ] Both projects target `net10.0`

## Core logic (4–12 min)

- [ ] Sent prompt 1 (contract included verbatim)
- [ ] `WordCount` record exists
- [ ] `TopWords(string text, int top)` exists, is `static`, and does no I/O
- [ ] Tokenizer uses `[A-Za-z0-9]+`
- [ ] Lowercasing uses `ToLowerInvariant()`
- [ ] Ordering is count desc, then `StringComparer.Ordinal` asc

## Tests, early (10–14 min)

- [ ] Sent prompt 2
- [ ] `dotnet test labs/05-build-analyzer/work/WordFrequency.Tests` **runs** (green or red)

## ⏱ Midpoint gate (13–14 min)

- [ ] Tests execute. **If not — send prompt 5 now.**

## CLI wiring (14–20 min)

- [ ] Sent prompt 3
- [ ] Logic is in a testable method taking `string[]`, output `TextWriter`, error `TextWriter`
- [ ] `Program.cs` is a one-liner
- [ ] Default `--top` is **10**
- [ ] Errors go to **stderr**

## Run and iterate (20–25 min)

- [ ] `dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 5`
- [ ] Output is exactly:
      `tests: 5` / `build: 3` / `code: 3` / `copilot: 3` / `practice: 3`
- [ ] `review` is **not** in the list (if it is, tie-break bug → prompt 6)
- [ ] Failures fed back with prompt 4 until green

## Verify (25–27 min)

- [ ] `dotnet test ...` → `Failed: 0`, `Total:` 5 or more
- [ ] no `--top` flag → **10** lines (the default)
- [ ] missing file → exit code `1`, message on stderr
- [ ] `--top zero` → exit code `2`
- [ ] `--help` → usage line, exit code `0`
- [ ] `--top 3` → `tests: 5` / `build: 3` / `code: 3`

## Done means

Green tests (≥5, including missing-file and empty-input), byte-exact sample output, the default `--top` of 10, correct exit codes, and counting logic in a pure `TopWords` method rather than in `Main`.

## Stretch (only after every box above is ticked)

- [ ] `--top all`
- [ ] stdin support when no path is given
- [ ] optional `--ignore` stop-word list, with a test proving the default is unchanged
- [ ] replace three `[Fact]`s with one `[Theory]` without losing a case
