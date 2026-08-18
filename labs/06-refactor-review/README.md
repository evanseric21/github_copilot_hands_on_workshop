# Lab 6 — Refactor and review (capstone B)

⬅️ [Lab 5 — Build the analyzer](../05-build-analyzer/README.md)

| | |
|---|---|
| **Timebox** | 19 minutes |
| **Copilot surface** | Agent mode for the refactor + **Copilot code review in the editor** (a pull request is optional) |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | `lab-refactor/WordFrequencyRefactor/` — working code that is not nice to read |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Take code that **works but is rough**, lock its behaviour with tests, clean it up in small moves, then get a second set of eyes on the diff from Copilot code review — and practise the professional part: **triaging** findings instead of blindly accepting them.

Generating code fast was Lab 5. This is the half that makes it shippable.

## Prerequisites

- Lab 0 passed.
- Lab 5 is **not** required. This lab uses its own starter project, so if Capstone A went sideways you start here with a clean slate.
- The starter implements the same [frozen contract](../05-build-analyzer/contract.md). Behaviour must not change — only structure.

## Definition of done

- [ ] You ran the characterization tests **before** touching any code and saw them pass.
- [ ] Counting and argument parsing are in small, well-named units; `Run` no longer does everything.
- [ ] Missing-file handling is still graceful and still exits `1`.
- [ ] You requested **at least one** Copilot code review on your changes.
- [ ] **At least two** findings are addressed **or** dismissed with a written rationale in [`review-notes.md`](review-notes.md).
- [ ] `dotnet test lab-refactor/WordFrequencyRefactor.Tests` is green afterwards, with no test weakened or deleted.

---

## Steps

### 1. Baseline — prove the tests pass *before* you change anything (0–3 min)

This is the single most important step in the lab. A refactor is only behaviour-preserving if you can prove what the behaviour was.

```powershell
# Working directory: repository root
dotnet test lab-refactor/WordFrequencyRefactor.Tests
```

Expected:

```text
Passed!  - Failed:     0, Passed:     8, Skipped:     0, Total:     8
```

**If this is not green, stop and fix the environment — do not refactor on a red baseline.** See the recovery table.

Also capture the real output so you can compare later. This run uses the default `--top` of **10**:

```powershell
# Working directory: repository root
dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt
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

And the explicit `--top 5` run, which must stay byte-identical through your refactor:

```powershell
# Working directory: repository root
dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt --top 5
```

```text
tests: 5
build: 3
code: 3
copilot: 3
practice: 3
```

### 2. Read the code (2 minutes, and worth every second)

```powershell
# Working directory: repository root
Get-Content lab-refactor/WordFrequencyRefactor/WordFrequencyAnalyzer.cs
Get-Content lab-refactor/WordFrequencyRefactor/CommandLineApp.cs
```

> **bash:** `cat lab-refactor/WordFrequencyRefactor/WordFrequencyAnalyzer.cs lab-refactor/WordFrequencyRefactor/CommandLineApp.cs`

What is rough here — the eight existing tests already lock all of it:

- `TopWords` does a double dictionary lookup (`ContainsKey` then indexer) and hand-rolls the sort and the take.
- `answer`, `sorted`, `left`, `right` say nothing about intent.
- `CommandLineApp.Run` parses arguments, validates them, reads a file, handles errors **and** prints results — four jobs, one method.
- The default top count is a bare `10` — the `var top = 10;` local near the top of `CommandLineApp.Run`, just above the argument-parsing loop.
- The usage string is duplicated.

### 3. Strengthen the characterization net (3–6 min)

Eight tests is a good net; make it a little tighter around the parts you are about to move. Send **prompt 1** from [`prompts/prompt-cards.md`](prompts/prompt-cards.md) to add tests for argument handling that nothing currently locks — no arguments at all, an unknown flag, and the `-h` short form.

Run them and confirm they pass **against the unrefactored code**. A characterization test that has never passed is not characterizing anything.

### 4. Refactor in small, named moves (6–12 min)

Send **prompt 2**. Ask for one move at a time and read every diff. Suggested moves, in order of payoff:

1. Extract argument parsing out of `Run` into its own method or small options type.
2. Replace the magic `10` — the `var top = 10;` default in `CommandLineApp.Run` — with a named constant.
3. Simplify the counting loop and the ordering to something intention-revealing.
4. Rename `answer`/`sorted`/`left`/`right` to say what they hold.
5. De-duplicate the usage string.

**Re-run the tests after every move**, not at the end:

```powershell
# Working directory: repository root
dotnet test lab-refactor/WordFrequencyRefactor.Tests
```

If a test goes red, the refactor changed behaviour. Revert that move — do not adjust the test.

### 5. Request a Copilot code review — in the editor (12–16 min)

This is the **primary** path and needs no network push, no branch, and no pull request:

- **VS Code:** open the **Source Control** view → **Copilot Code Review – Uncommitted Changes**.
- Or select a method in the editor, right-click, and choose the Copilot review option to review just that selection.

Two things to know before you read the results:

- Copilot code review always leaves a **Comment**-type review. It does not approve, does not request changes, and does not count toward required approvals. It is an assistant, not a gatekeeper.
- Some sub-features are preview, so exact menu wording may vary by version. If you cannot find the entry point, use **prompt 3** — a chat-based review of your diff is a legitimate substitute.

### 6. Triage — the actual skill (16–19 min)

Open [`review-notes.md`](review-notes.md) and record **at least two** findings. For each one, pick a verdict:

- **Addressed** — you agreed and changed the code. Note what you changed.
- **Dismissed** — you disagreed. Note **why**. "The contract requires `StringComparer.Ordinal`, so switching to `StringComparison.OrdinalIgnoreCase` would change documented behaviour" is a first-class professional outcome.

Copilot advises. You decide. Dismissing with a reason is not laziness — it is the job.

### 7. Re-run the tests one last time

```powershell
# Working directory: repository root
dotnet test lab-refactor/WordFrequencyRefactor.Tests
dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt --top 5
```

Same green count as your baseline (8 plus any you added), and the same five output lines.

## Copy/paste prompts

Full set in [`prompts/prompt-cards.md`](prompts/prompt-cards.md). The refactor prompt:

```text
Refactor lab-refactor/WordFrequencyRefactor. Behaviour must not change - the tests in
lab-refactor/WordFrequencyRefactor.Tests define the contract and must stay untouched and green.

Do these one at a time, showing me the diff and pausing after each:
1. Extract argument parsing out of CommandLineApp.Run into its own well-named unit.
2. Replace the magic default top count of 10 with a named constant.
3. Simplify the counting and ordering in WordFrequencyAnalyzer.TopWords so the
   count-descending then StringComparer.Ordinal-ascending rule is obvious at a glance.
4. Rename answer, sorted, left and right to intention-revealing names.

Rules: do not change any public signature, do not change output text or exit codes,
do not edit or delete any test. After each step, run:
dotnet test lab-refactor/WordFrequencyRefactor.Tests
```

## Midpoint checkpoint (at 9–10 minutes)

You should have a **green test run after at least one completed refactor move**.

If you are still reading code at 10 minutes, do exactly one move — extract argument parsing — and go straight to the review step. **A small clean diff that gets reviewed beats a big refactor that never does.** The review and the triage are where the learning is.

The facilitator will call time at **10 minutes** and **16 minutes**.

## Verify

**1. Baseline was green before the refactor** — you ran step 1 and saw `Passed: 8`.

**2. Still green after:**

```powershell
# Working directory: repository root
dotnet test lab-refactor/WordFrequencyRefactor.Tests
```

Expect `Failed: 0` and a total of **8 or more** (more if you added characterization tests). Fewer than 8 means a test was deleted — put it back.

**3. Behaviour is unchanged:**

```powershell
# Working directory: repository root
dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt          # 10 lines (default)
dotnet run --project lab-refactor/WordFrequencyRefactor -- samples/sample.txt --top 5  # the pinned five
dotnet run --project lab-refactor/WordFrequencyRefactor -- no-such-file.txt
$LASTEXITCODE    # expect 1
```

> **bash:** `echo $?` instead of `$LASTEXITCODE`.

**4. There is a real diff:**

```powershell
# Working directory: repository root
git diff --stat lab-refactor
```

**5. Two findings are written down** in [`review-notes.md`](review-notes.md), each with a verdict and a rationale.

## No-push / no-PR fallback (this is the default path)

**You never need a remote in this lab.** The editor-local review works entirely on uncommitted changes in your working tree.

If git is unavailable or blocked, the review still works — Copilot reviews your **uncommitted changes**, which exist whether or not git can talk to a server. Worst case, use prompt 3 to review pasted code in chat.

Optional local checkpoint:

```powershell
# Working directory: repository root
git switch -c lab6-refactor
git add lab-refactor
git commit -m "Refactor word frequency analyzer"
```

Optional enrichment, only if your laptop and network allow it and you already finished the core path: push the branch and request Copilot as a reviewer on the pull request (**PR → Reviewers → Copilot → Request**). Nothing in the definition of done depends on it.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| Baseline tests fail before you change anything | Run `dotnet build GitHubCopilotWorkshop.sln` from the repository root, confirm `dotnet --version` is 10.x, then retry. Do not refactor on red. |
| A test goes red mid-refactor | Behaviour changed. `git restore lab-refactor` (repository root) resets to the starter, or undo just the last move. **Never** edit the test to make it pass. |
| Agent mode rewrote everything at once | Undo, then re-send prompt 2 with `Do step 1 only. Stop and show me the diff.` One move at a time is the technique, not a formality. |
| You cannot find the code review entry point | Use prompt 3 — a chat review of your diff. It satisfies the definition of done. |
| The review returns nothing useful | Review a smaller scope: select one method and review just that. Reviews of huge diffs get vague. |
| You have zero findings to triage | Ask prompt 4 for the top three concerns with severities. If there is genuinely nothing, write that down as your rationale — "reviewed, no actionable findings, here is what it checked" is an honest entry. |
| Out of time entirely | Do one extraction, request one review, write one honest line per finding. That is a complete pass of the loop, which is the objective. |

## Stretch (optional, intermediate)

- Make `TopWords` allocate less on a large input **without** changing observable behaviour. Your tests are the proof.
- Add a `[Theory]` that replaces several `[Fact]`s without losing a case.
- Ask Copilot to review the same diff twice — once with `focus on correctness and edge cases`, once with `focus on readability and naming`. Compare. Focused reviews are noticeably sharper.
- Add a test for a behaviour that is currently *undefined* by the contract (a directory passed instead of a file, a zero-byte file). Decide what should happen, write it down, then implement it.
- If you have push rights and time: open a pull request and request Copilot as a reviewer. Compare the PR review with the editor review — same engine, different surface, different amount of context.

## Reflect (60 seconds)

Which finding did you **dismiss**, and could you defend that decision to a colleague in one sentence?

That sentence is the whole point of this lab. Copilot review is a fast first pass, not the last word — and the judgement about which advice to take is the part that stays yours.

## Next

The workshop wraps up here. Two things worth doing before you close the laptop:

- If you skipped it, [Lab 4 — MCP literacy](../04-mcp-literacy/README.md) is a 3-minute read on your own.
- The stretch goals in [Lab 5](../05-build-analyzer/README.md#stretch-optional-intermediate) are the best way to keep practising this week.

And on Monday: seed one of your own repositories with a `.github/instructions/*.instructions.md`. It is the cheapest habit from today and the one that compounds.
