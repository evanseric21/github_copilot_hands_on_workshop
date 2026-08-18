# Lab 6 — checklist

19 minutes. Working directory is the repository root for every command.

## ⚠️ Baseline first (0–3 min) — do not skip

- [ ] `dotnet test lab-refactor/WordFrequencyRefactor.Tests` → `Passed: 8, Failed: 0`
- [ ] `dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt`
      prints **10** lines (the default), starting `tests: 5` and ending `the: 2`
- [ ] `dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt --top 5`
      prints `tests: 5` / `build: 3` / `code: 3` / `copilot: 3` / `practice: 3`
- [ ] Baseline recorded in [`review-notes.md`](review-notes.md)

**Red baseline = stop and fix the environment. Never refactor on red.**

## Read the code (2–4 min)

- [ ] Read `WordFrequencyAnalyzer.cs` and `CommandLineApp.cs`
- [ ] Spotted at least three rough edges (double dictionary lookup, `Run` doing four jobs, the magic default `10`, opaque names, duplicated usage string)

## Characterization tests (3–6 min)

- [ ] Sent prompt 1 (no-arguments, unknown flag, `-h` short form)
- [ ] New tests **pass against the unrefactored code**
- [ ] Total test count is now ≥ 8

## Refactor, one move at a time (6–12 min)

- [ ] Move 1: argument parsing extracted out of `Run` → tests green
- [ ] Move 2: magic `10` replaced with a named constant → tests green
- [ ] Move 3: counting/ordering made obvious at a glance → tests green
- [ ] Move 4: `answer` / `sorted` / `left` / `right` renamed → tests green
- [ ] No public signature, output string, or exit code changed
- [ ] No test edited or deleted

## ⏱ Midpoint gate (9–10 min)

- [ ] At least one refactor move done **and** tests green. If not — do the argument-parsing extraction only and go straight to the review.

## Copilot code review (12–16 min)

- [ ] Requested a review on **uncommitted changes** in the editor (Source Control → Copilot Code Review – Uncommitted Changes), or reviewed a selection
- [ ] Fallback used if needed: chat review via prompt 3
- [ ] Read every finding before acting on any of them

## Triage (16–19 min)

- [ ] Finding 1 recorded in `review-notes.md` with a verdict
- [ ] Finding 2 recorded in `review-notes.md` with a verdict
- [ ] Every **Dismissed** verdict has a written rationale
- [ ] Every **Addressed** verdict names the change made

## Final verification

- [ ] `dotnet test lab-refactor/WordFrequencyRefactor.Tests` → `Failed: 0`, total ≥ baseline
- [ ] Default run still prints 10 lines; `--top 5` still prints the pinned five
- [ ] Missing file still exits `1`
- [ ] `git diff --stat lab-refactor` shows a real diff

## Optional (only after everything above)

- [ ] Local branch + commit (no remote needed)
- [ ] Push and request Copilot as a PR reviewer — **enrichment only, never required**

## Done means

Logic extracted out of one do-everything method, intention-revealing names, graceful missing-file handling, tests still green, **≥1 review requested**, and **≥2 findings addressed or dismissed with rationale**.
