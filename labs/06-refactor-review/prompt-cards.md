# Lab 6 — prompt cards

Working directory = repository root. Seven cards: prompts 1–2 are the refactor path, 3–6 cover review and triage, and 7 is an optional stretch.

---

## Prompt 1 — strengthen the characterization net (send at ~minute 3)

```text
Add xUnit tests to labs/06-refactor-review/starter/WordFrequencyRefactor.Tests that lock in argument-handling
behaviour that nothing currently covers, so I can refactor CommandLineApp safely:

1. Running with no arguments at all writes a message to the error writer and returns exit code 2.
2. Running with a valid file path followed by an unknown flag such as --nope writes
   "Unknown argument: --nope" to the error writer and returns exit code 2.
3. Running with "-h" as the only argument prints the usage line to the output writer
   and returns exit code 0.

Use the existing test style: CommandLineApp.Run with StringWriter for output and error.
Do not change any production code. These tests must pass against the current implementation -
if one fails, tell me what the current behaviour actually is instead of "fixing" the code.

Then run: dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
```

> The default `--top` value is already locked by the existing `Run_PrintsDefaultTopTenWords` test,
> so there is no need to write that one yourself — read it instead, it is a good example of what a
> characterization test looks like.

---

## Prompt 2 — refactor, one move at a time (send at ~minute 6)

```text
Refactor labs/06-refactor-review/starter/WordFrequencyRefactor. Behaviour must not change - the tests in
labs/06-refactor-review/starter/WordFrequencyRefactor.Tests define the contract and must stay untouched and green.

Do these one at a time, showing me the diff and pausing after each:
1. Extract argument parsing out of CommandLineApp.Run into its own well-named unit.
2. Replace the magic default top count of 10 with a named constant.
3. Simplify the counting and ordering in WordFrequencyAnalyzer.TopWords so the
   count-descending then StringComparer.Ordinal-ascending rule is obvious at a glance.
4. Rename answer, sorted, left and right to intention-revealing names.

Rules: do not change any public signature, do not change output text or exit codes,
do not edit or delete any test. After each step, run:
dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
```

If agent mode charges ahead, rein it in:

```text
Do step 1 only. Stop after it and show me the diff.
```

---

## Prompt 3 — chat-based code review (fallback if the review UI is unavailable)

```text
Act as a senior C# reviewer. Review this diff for correctness, naming, error handling and
testability. For each finding give: severity (high/medium/low), the file and line, the concern
in one sentence, and a concrete suggested change.

Do not rewrite the code. List findings only, most severe first.

<paste the output of: git diff labs/06-refactor-review/starter>
```

---

## Prompt 4 — when the review comes back empty or vague

```text
Review labs/06-refactor-review/starter/WordFrequencyRefactor/CommandLineApp.cs and
labs/06-refactor-review/starter/WordFrequencyRefactor/WordFrequencyAnalyzer.cs.

Give me exactly the top 3 concerns you would raise in a pull request, ranked by severity,
each with a one-line justification and a concrete suggested change. Be specific about
line-level issues; skip anything stylistic that an .editorconfig already covers.
```

---

## Prompt 5 — apply an accepted finding safely

```text
I am accepting this review finding:

<paste the finding>

Apply the smallest change that resolves it. Do not touch anything else, do not change any
public signature, output text or exit code, and do not edit any test.
Then run: dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
```

---

## Prompt 6 — pressure-test a finding before you dismiss it

Use this when you think the reviewer is wrong. Sometimes it is; sometimes you are.

```text
This review finding says:

<paste the finding>

The frozen behaviour contract for this project requires: tokens matching [A-Za-z0-9]+,
ToLowerInvariant, ordering by count descending then word ascending with StringComparer.Ordinal,
CLI "analyzer <path> [--top N]" with default 10, and exit codes 0/1/2.

Would applying this finding change any of that observable behaviour? Answer yes or no first,
then justify in two sentences.
```

A "yes" is a legitimate dismissal, and prompt 6's answer is the rationale you write into `review-notes.md`.

---

## Prompt 7 — stretch: focused reviews

Run the same diff through two different lenses and compare.

```text
Review my uncommitted changes in labs/06-refactor-review/starter with a single focus: correctness and edge cases.
Ignore style entirely.
```

```text
Now review the same changes with a single focus: readability and naming.
Ignore correctness entirely.
```
