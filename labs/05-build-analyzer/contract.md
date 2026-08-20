# The frozen contract

Read this **before** you start Lab 5. Every rule here is fixed for the whole workshop: Lab 5 builds to it, Lab 6 refactors code that already implements it, and the repository's own tests assert it.

Why freeze it? Because a total order with no ambiguity means:

- every laptop in the room produces **byte-identical output** for the same input,
- tests are deterministic — no "works on my machine" ordering flakiness,
- when Copilot invents something different, you can tell immediately.

**If Copilot suggests a "better" rule, the contract wins.** Note the disagreement, keep the contract.

---

## 1. Tokenization

- A **token** is a match of the regular expression `[A-Za-z0-9]+`.
- Every character that is not an ASCII letter or ASCII digit **separates** tokens: spaces, newlines, punctuation, hyphens, apostrophes, underscores, accented letters, emoji.
- **No stop words are removed.** `the`, `and`, `a` all count.
- Every token is lowercased with **`ToLowerInvariant()`** (not `ToLower()`, which is culture-dependent).

Worked examples:

| Input | Tokens |
|---|---|
| `Hello, world!` | `hello`, `world` |
| `word.` | `word` |
| `The THE the` | `the`, `the`, `the` → `the: 3` |
| `don't` | `don`, `t` — the apostrophe separates |
| `state-of-the-art` | `state`, `of`, `the`, `art` |
| `snake_case` | `snake`, `case` — the underscore separates |
| `42 tests` | `42`, `tests` — **digits are words** |
| `café` | `caf` — `é` is not ASCII, so it separates |

The last two surprise people. They are deliberate: ASCII-only keeps the rule explainable in one line and identical on every machine and locale.

## 2. Counting

- Count occurrences of each **distinct lowercased token**.
- Use an ordinal-keyed dictionary (`StringComparer.Ordinal`) so keys never fold together under a culture's casing rules.

## 3. Ordering — a total order

Sort by:

1. **Count, descending.**
2. Then **word, ascending, using `StringComparer.Ordinal`.**

Then take the first `top` results.

`StringComparer.Ordinal` compares by character code, not by alphabet rules. Two consequences worth knowing:

- Digits sort **before** letters: on a tie, `42` comes before `alpha`.
- Comparison is not culture-aware, which is exactly what makes it reproducible.

Because no two distinct words can be equal under the second key, **there is exactly one correct ordering for any input.**

The classic tie in this workshop:

> `build`, `code`, `copilot`, `practice` and `review` all appear **3** times in `samples/sample.txt`.
> Ordinal ascending puts them in that order, so `--top 5` includes `practice` and excludes `review`.

If `review` appears in your top 5, your tie-break is wrong.

## 4. The API shape

```csharp
public sealed record WordCount(string Word, int Count);

public static class WordFrequencyAnalyzer
{
    public static IReadOnlyList<WordCount> TopWords(string text, int top);
}
```

- `TopWords` is **pure**: no `Console`, no file I/O, no static mutable state.
- `top <= 0` returns an **empty list** (not `null`, not an exception).
- `top` larger than the number of distinct words returns every word.

## 5. The CLI contract

```text
Usage: analyzer <path> [--top N]
```

- `<path>` is required and comes first.
- `--top N` is optional. **Default N = 10.**
- `N` must be a positive whole number.
- `--help` or `-h`, used as the only argument, prints the usage line to **stdout** and exits `0`.

### Output format

One line per word, in contract order, written to **stdout**:

```text
word: count
```

Word, colon, single space, count. Nothing else — no header, no ranking numbers, no blank lines.

### Exit codes

| Code | Meaning | Where the message goes |
|---|---|---|
| `0` | Success, or `--help` | stdout |
| `1` | File problem — not found, unreadable, permission denied | **stderr** |
| `2` | Argument problem — missing path, unknown flag, bad `--top` value | **stderr** |

Error messages go to **stderr**, never stdout. That is what makes the tool pipeable.

Suggested messages (match these if you want your output to match the room's):

- missing path → `Missing path.` followed by the usage line
- unknown flag → `Unknown argument: <arg>`
- bad `--top` → a message containing `--top`
- missing file → `File not found: <path>`

## 6. Pinned expected output

Input is the shared `samples/sample.txt` at the repository root. Run from the repository root.

No `--top` flag — the default of 10:

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

`--top 5`:

```text
tests: 5
build: 3
code: 3
copilot: 3
practice: 3
```

`--top 3`:

```text
tests: 5
build: 3
code: 3
```

`--help`:

```text
Usage: analyzer <path> [--top N]
```

A file that does not exist:

```text
File not found: no-such-file.txt
```

...on stderr, exit code `1`.

## Sample text provenance

`samples/sample.txt` is original text written for this workshop. With token regex `[A-Za-z0-9]+`, invariant lowercase, no stop words, and ordering by count descending then `StringComparer.Ordinal` ascending ties, the expected top 5 are:

1. `tests: 5`
2. `build: 3`
3. `code: 3`
4. `copilot: 3`
5. `practice: 3`

`review` also appears 3 times and is excluded from the top 5 by the ordinal tie-break.

## 7. Prompt-ready version

Paste this block into Copilot when you want the contract in a prompt:

```text
Frozen behaviour contract - implement exactly this, do not improve on it:
- A token is a match of the regex [A-Za-z0-9]+. Every other character separates tokens.
- Lowercase every token with ToLowerInvariant(). Do not remove stop words.
- Count occurrences per distinct token using an ordinal-keyed dictionary.
- Order by count descending, then by word ascending using StringComparer.Ordinal.
- Return the first `top` results; return an empty list when top <= 0.
- CLI: analyzer <path> [--top N], default N = 10; output lines are "word: count" on stdout.
- Exit codes: 0 success or --help, 1 file problem, 2 argument problem. Errors go to stderr.
```

## 8. Where this contract is already asserted

You do not have to take it on faith — it is executable in this repository:

- `labs/06-refactor-review/starter/WordFrequencyRefactor.Tests/WordFrequencyAnalyzerTests.cs` — tokenizing, casing, digits, ordinal ties, and the pinned sample top 5.
- `labs/06-refactor-review/starter/WordFrequencyRefactor.Tests/CommandLineAppTests.cs` — help text, exit codes, the default top 10, and the printed output for an explicit `--top 5`.
- `samples/sample.txt` — original workshop text used for pinned output checks.

Run them any time:

```powershell
# Working directory: repository root
dotnet test labs/06-refactor-review/starter/WordFrequencyRefactor.Tests
```

Expect `Passed!` with 8 tests.
