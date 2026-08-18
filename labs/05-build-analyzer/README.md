# Lab 5 — Build the analyzer (capstone A)

⬅️ [Lab 4 — MCP literacy](../04-mcp-literacy/README.md)

| | |
|---|---|
| **Timebox** | 27 minutes — the longest block of the day. Protect it. |
| **Copilot surface** | Copilot Chat — **Agent** mode (let it scaffold, edit, and run commands) |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop` |
| **Starting point** | An empty folder: `labs/05-build-analyzer/work/`. There is no starter code — that is the point. |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Go from nothing to a **tested, working C# CLI** that prints the most frequent words in a text file — driven by agent mode, verified by `dotnet test`, and matching a **frozen behaviour contract** so that everyone in the room gets byte-identical output.

Everything from the morning lands here: Lab 1 taught you to write the prompt, Lab 2 made Copilot follow your conventions, Lab 3 gave it a procedure for tests.

## Prerequisites

- Lab 0 passed (`dotnet --version` shows 10.x, NuGet restore works).
- **Read [`contract.md`](contract.md) first.** Two minutes there saves ten minutes of guessing. The contract is frozen: tokenizing, ordering, CLI shape, and exit codes are not up to you or to Copilot.
- Optional but useful: the instruction file from Lab 2 and the skill from Lab 3 are still active and will influence what agent mode produces.

## The frozen contract in one screen

Full detail — including every exit code and the exact expected output — is in [`contract.md`](contract.md). The short version:

| Rule | Value |
|---|---|
| Token | a match of `[A-Za-z0-9]+`; every other character separates words |
| Case | `ToLowerInvariant()` on every token |
| Stop words | none removed |
| Order | count **descending**, then word **ascending** by `StringComparer.Ordinal` |
| Core API | `public static IReadOnlyList<WordCount> TopWords(string text, int top)` |
| Record | `public sealed record WordCount(string Word, int Count);` |
| CLI | `analyzer <path> [--top N]`, default **N = 10** |
| Output line | `word: count` |
| Exit codes | `0` success/help · `1` file problem · `2` argument problem |

This is a **total order** — no two words can tie after both keys are applied, so there is exactly one correct answer for any input. That is what makes the whole room's output comparable and the tests deterministic.

## Definition of done

- [ ] `dotnet test` on your test project is **green** with **at least 5 meaningful tests**, including a missing-file case and an empty-input case.
- [ ] `dotnet run ... -- samples/sample.txt --top 5` prints exactly the five lines in [Verify](#verify).
- [ ] Running with no `--top` flag prints **10** lines — the default.
- [ ] A missing file exits with code `1` and a clear message on **stderr**.
- [ ] Bad arguments exit with code `2`.
- [ ] The counting logic lives in a pure `TopWords` method — not in `Main`.

---

## Steps

### 1. Scaffold (target: done by minute 4)

Let agent mode run these, or run them yourself — they are identical either way:

```powershell
# Working directory: repository root
dotnet new console -n WordFrequency -o labs/05-build-analyzer/work/WordFrequency
dotnet new xunit -n WordFrequency.Tests -o labs/05-build-analyzer/work/WordFrequency.Tests
dotnet reference add labs/05-build-analyzer/work/WordFrequency/WordFrequency.csproj --project labs/05-build-analyzer/work/WordFrequency.Tests/WordFrequency.Tests.csproj
```

> **bash:** the same three commands, unchanged — forward slashes already work in both shells.
> **Older SDKs:** `dotnet add <project> reference <ref>` still works if you are not on the .NET 10 noun-first CLI.

Both templates default to `net10.0` and the test template already references `xunit.v3`.

### 2. Core logic (target: done by minute 12)

Send **prompt 1** from [`prompts/prompt-cards.md`](prompts/prompt-cards.md). It carries the whole contract, so do not paraphrase it — paste it.

Read what comes back before accepting. You are looking for: a `static` method, the exact signature, `[A-Za-z0-9]+`, `ToLowerInvariant()`, and an ordinal tie-break.

### 3. Tests, early (target: first run by minute 14)

Send **prompt 2**. Ask for tests *before* the CLI is finished — failures are how you steer agent mode, and a red test is more useful than a hopeful one.

```powershell
# Working directory: repository root
dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
```

### 4. CLI wiring (target: done by minute 20)

Send **prompt 3**. Keep `Main` thin: parse arguments, call `TopWords`, write lines. The contract's exit codes are non-negotiable, and testable argument handling is much easier if the logic lives in a method that takes a `string[]` and two `TextWriter`s rather than touching `Console` directly.

### 5. Run it on the shared sample (target: by minute 25)

```powershell
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 5
```

Everyone in the room uses this same `samples/sample.txt`, so your output must match the room's. Compare against [Verify](#verify).

### 6. Iterate to green (last 2 minutes)

Feed failures straight back to agent mode with **prompt 4**. Do not chase elegance — chase green.

## Copy/paste prompts

All six live in [`prompts/prompt-cards.md`](prompts/prompt-cards.md) — prompts 1–4 are the core path in order, prompt 5 is the rescue, prompt 6 fixes the two classic bugs. Prompt 1, the one that matters most:

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
- Count occurrences per distinct token.
- Order by count descending, then by word ascending using StringComparer.Ordinal.
- Return the first `top` results; return an empty list when top <= 0.
- No Console output, no file I/O, no Main changes in this step. Pure function only.

Do not create a solution file and do not modify any project outside
labs/05-build-analyzer/work/.
```

## Midpoint checkpoint (at 13–14 minutes)

You should be able to run this and see tests **execute** — passing or failing, but running:

```powershell
# Working directory: repository root
dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
```

**If tests are not running yet at 14 minutes, switch to the fallback track:** go to [`prompts/prompt-cards.md`](prompts/prompt-cards.md) and send prompt 5, the single "build all of it" prompt. It is a bigger bite for agent mode, but it gets you to something runnable with 13 minutes still on the clock. Finishing with help beats not finishing.

The facilitator will call time at **10 minutes** and **20 minutes**.

## Verify

**1. Exact sample output** — this is the one that must match the room:

```powershell
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

`review` also appears 3 times. It is **not** in the top 5 because `StringComparer.Ordinal` puts `practice` before `review`. If you see `review` in your list, your tie-break is wrong — that is the single most common bug in this lab.

**2. The default is 10** — omitting `--top` prints ten lines:

```powershell
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

**3. Tests green, at least five of them:**

```powershell
# Working directory: repository root
dotnet test labs/05-build-analyzer/work/WordFrequency.Tests
```

Expect a `Passed!` line with `Failed: 0` and `Total:` of 5 or more.

**4. Exit codes:**

```powershell
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- no-such-file.txt
$LASTEXITCODE    # expect 1

dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top zero
$LASTEXITCODE    # expect 2

dotnet run --project labs/05-build-analyzer/work/WordFrequency -- --help
$LASTEXITCODE    # expect 0
```

> **bash:** replace `$LASTEXITCODE` with `echo $?` on the line after each command.

**5. Smaller top still ordered correctly:**

```powershell
# Working directory: repository root
dotnet run --project labs/05-build-analyzer/work/WordFrequency -- samples/sample.txt --top 3
```

```text
tests: 5
build: 3
code: 3
```

## No-push / no-PR fallback

Nothing in this lab is pushed or reviewed remotely. Everything lives in your working tree.

Optional local checkpoint, no remote required:

```powershell
# Working directory: repository root
git add labs/05-build-analyzer/work
git commit -m "Capstone A: word frequency analyzer"
```

If git is blocked on your laptop entirely, skip it — your files on disk are the deliverable, and Lab 6 uses a different project.

## Beginner recovery path

| Time | Symptom | Fix |
|---|---|---|
| any | Scaffold commands fail | Check you are in the repository root and `dotnet --version` is 10.x. Re-run the exact commands from step 1 rather than retyping them. |
| any | `review: 3` shows up in your top 5 | Your tie-break is not ordinal. Send: `Ties must be broken by word ascending using StringComparer.Ordinal, not the default string comparison. Fix only that.` |
| any | Counts are too high / punctuation attached | The tokenizer is splitting on whitespace instead of matching `[A-Za-z0-9]+`. Send prompt 6 from the cards. |
| any | Agent mode edited files outside `work/` | `git status` (repository root) to see what moved, then `git restore <path>` for anything you did not intend to change. |
| any | `dotnet test` finds no tests | The test project needs a `ProjectReference` to `WordFrequency`. Re-run the third scaffold command. |
| 14 min | Nothing runs yet | Send prompt 5 — the single "build all of it" prompt. |
| 20 min | Still stuck | Open `lab-refactor/WordFrequencyRefactor/` in this repo. It is a **deliberately rough but working** implementation of the same frozen contract — read it, understand the shape, and use it to unblock yourself. (You will clean it up in Lab 6.) Reading working code is a legitimate way to learn; copying it without reading it is not. |
| any | You are behind and demoralised | Pair with your neighbour, one keyboard. Finishing together beats two half-finished laptops, and it is faster. |

## Stretch (optional, intermediate)

Only start these once the definition of done is fully green.

- `--top all` prints every distinct word.
- Read from **stdin** when no path is given, so `Get-Content samples/sample.txt | dotnet run --project ... ` works.
- Add an optional `--ignore` stop-word list — and add a test proving the default behaviour is unchanged, because the contract says no stop words by default.
- Ask Copilot for a `[Theory]` that replaces three of your `[Fact]` tests without losing a case.
- Benchmark on a large file and ask Copilot to reduce allocations **without** changing observable behaviour. Your tests are the proof it worked.

## Reflect (60 seconds)

Where did agent mode need correcting — the tokenizer, the tie-break, or the CLI?
That is the part of the contract your prompt stated least precisely. Prompts are specifications; the vague part is always where the bug lands.

## Next

➡️ [Lab 6 — Refactor and review](../06-refactor-review/README.md)
