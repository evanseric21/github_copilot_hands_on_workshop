# Lab 5 — prompt cards

Six cards. Prompts 1–4 are the core path in order. Prompt 5 is the "I am behind" rescue. Prompt 6 fixes the most common bug.

All of them assume **agent mode**, working directory = repository root.

---

## Prompt 1 — core logic (send at ~minute 4)

```text
You are working in the repository root of github_copilot_hands_on_workshop, in agent mode.

Goal: implement the core of a word-frequency analyzer in the existing project at
labs/05-build-analyzer/work/WordFrequency (net10.0).

Create WordCount.cs and WordFrequencyAnalyzer.cs in that project, in namespace WordFrequency:

    public sealed record WordCount(string Word, int Count);

    public static class WordFrequencyAnalyzer
    {
        public static IReadOnlyList<WordCount> TopWords(string text, int top);
    }

Frozen behaviour contract - implement exactly this, do not improve on it:
- A token is a match of the regex [A-Za-z0-9]+. Every other character separates tokens.
- Lowercase every token with ToLowerInvariant(). Do not remove stop words.
- Count occurrences per distinct token using an ordinal-keyed dictionary.
- Order by count descending, then by word ascending using StringComparer.Ordinal.
- Return the first `top` results; return an empty list when top <= 0.
- No Console output, no file I/O, no Main changes in this step. Pure function only.

Do not create a solution file and do not modify any project outside
labs/05-build-analyzer/work/.
```

---

## Prompt 2 — tests, early (send at ~minute 10)

```text
Add xUnit tests for WordFrequencyAnalyzer.TopWords in the project at
labs/05-build-analyzer/work/WordFrequency.Tests.

Cover exactly these cases, one test each unless a [Theory] removes real duplication:
1. Case-insensitive combining: "The THE the" produces the: 3.
2. Punctuation stripped: "word. word" produces word: 2.
3. Digits are tokens: "42 42 alpha" puts 42 before alpha.
4. Ordinal tie-break: input "beta beta alpha alpha" with top 2 returns alpha then beta
   because counts tie and StringComparer.Ordinal orders ascending.
5. top <= 0 returns an empty list.
6. Empty input returns an empty list.

Name tests Method_Scenario_Expected. Do not modify WordFrequencyAnalyzer to make a test pass -
if a test fails, tell me which contract rule the implementation is breaking.

Then run: dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
```

---

## Prompt 3 — CLI wiring (send at ~minute 14)

```text
Wire up the console app in labs/05-build-analyzer/work/WordFrequency.

CLI contract:
- Usage line, exactly: Usage: analyzer <path> [--top N]
- <path> is required and comes first; --top N is optional and defaults to 10.
- N must be a positive whole number.
- "--help" or "-h" as the only argument prints the usage line to stdout and exits 0.
- Success prints one line per word to stdout in the format "word: count", then exits 0.
- File not found or unreadable: message to stderr, exit code 1.
- Missing path, unknown argument, or bad --top value: message to stderr, exit code 2.

Structure it so the behaviour is testable: put the logic in a method that takes
string[] args, a TextWriter for output and a TextWriter for errors, and returns the exit code.
Keep Program.cs to a single line that calls it with Console.Out and Console.Error.

Then add xUnit tests for: help text and exit 0, missing file and exit 1, bad --top and exit 2,
and a successful run producing the expected lines.
```

---

## Prompt 4 — iterate on failures

```text
Here is the failing output from dotnet test:

<paste the failure block>

Fix only the production code needed to satisfy the frozen contract. Do not weaken or delete
a test to make it pass. Tell me in one sentence which contract rule was being broken.
```

---

## Prompt 5 — rescue path (send if nothing runs by minute 14)

One prompt, whole feature. Bigger bite, less control — the right trade when the clock is winning.

```text
In agent mode, build a complete word-frequency analyzer in the existing projects at
labs/05-build-analyzer/work/WordFrequency and labs/05-build-analyzer/work/WordFrequency.Tests
(net10.0, namespace WordFrequency). Do not touch anything outside labs/05-build-analyzer/work/.

Frozen behaviour contract - implement exactly this, do not improve on it:
- A token is a match of the regex [A-Za-z0-9]+. Every other character separates tokens.
- Lowercase every token with ToLowerInvariant(). Do not remove stop words.
- Order by count descending, then by word ascending using StringComparer.Ordinal.
- public sealed record WordCount(string Word, int Count);
- public static IReadOnlyList<WordCount> TopWords(string text, int top); pure, no I/O,
  returns an empty list when top <= 0.
- CLI: analyzer <path> [--top N], default N = 10, output lines "word: count" on stdout.
- --help or -h alone prints "Usage: analyzer <path> [--top N]" and exits 0.
- Exit codes: 0 success or help, 1 file problem, 2 argument problem; errors go to stderr.

Add at least 5 xUnit tests including a missing-file case and an empty-input case.

Then run these two commands and show me the output:
  dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
  dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 5

The second command must print exactly:
tests: 5
build: 3
code: 3
copilot: 3
practice: 3
```

---

## Prompt 6 — fix the two classic bugs

**Wrong tie-break** (you see `review` in the top 5):

```text
My top 5 includes "review" but it should include "practice". Ties on equal counts must be
broken by word ascending using StringComparer.Ordinal, not the default string comparison
and not insertion order. Fix only the ordering, then re-run the tests.
```

**Wrong tokenizer** (counts too high, punctuation attached to words):

```text
The tokenizer is wrong. Do not split on whitespace. Instead, extract tokens by matching the
regex [A-Za-z0-9]+ against the text, so "Hello, world!" yields exactly hello and world, and
"don't" yields don and t. Every non-ASCII-alphanumeric character is a separator.
Fix only the tokenizer, then re-run the tests.
```
