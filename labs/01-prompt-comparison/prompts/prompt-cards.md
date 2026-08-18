# Lab 1 — prompt cards (beginner fallback)

These are complete, ready-to-run rewrites. Using them is **not cheating** — it is the fallback track.
Run the card as-is, then change one line and run it again. Editing a good prompt teaches faster than staring at an empty one.

All three cards target the same C#/.NET domain you will build in Lab 5, so nothing here is throwaway.

---

## Card 1 — replaces `make a function`

```text
Act as a senior C# developer working in .NET 10.

Goal: write one pure static method that returns the most frequent words in a block of text.

Signature: public static IReadOnlyList<WordCount> TopWords(string text, int top)
where WordCount is: public sealed record WordCount(string Word, int Count);

Constraints:
- A token is a match of the regex [A-Za-z0-9]+. Everything else separates words.
- Lowercase every token with ToLowerInvariant(). Do not remove stop words.
- Order by count descending, then by word ascending using StringComparer.Ordinal.
- Return an empty list when top <= 0.
- No file I/O, no Console calls, no Main method. Pure function only.

Return the method and the record, nothing else.
```

**What changed:** role, exact signature, exact tokenizing rule, exact ordering rule, an edge case, and an explicit list of things *not* to do.

---

## Card 2 — replaces `fix this`

Select the `CountWords` snippet from [`weak-prompts.md`](weak-prompts.md) in the editor first, then send:

```text
This C# method is supposed to count how many words are in a string, but it is wrong.

Current behaviour: "Hello,  world" returns 3 because it splits on a single space and
counts the empty string, and "word." is treated as a different word from "word".

Expected behaviour: count the number of tokens matching the regex [A-Za-z0-9]+,
so "Hello,  world" returns 2.

Constraints:
- Keep the method name and the public static signature.
- Do not add a Main method or Console output.
- Explain the root cause in one sentence before you show the fixed code.
```

**What changed:** the symptom, an input with its wrong output and its expected output, a scope limit ("keep the signature"), and an ordering instruction ("explain first").

---

## Card 3 — replaces `write tests`

```text
Write xUnit tests in C# for this method:

    public static IReadOnlyList<WordCount> TopWords(string text, int top)

Behaviour under test:
- Tokens are matches of [A-Za-z0-9]+; everything else separates words.
- Tokens are lowercased with ToLowerInvariant, so "The" and "the" combine.
- Results are ordered by count descending, then by word ascending with StringComparer.Ordinal.
- top <= 0 returns an empty list.

Cover these cases:
1. case-insensitive combining
2. punctuation stripped ("word." counts as "word")
3. digits are valid words ("42" is a token)
4. an alphabetical tie broken by StringComparer.Ordinal
5. top larger than the number of distinct words
6. empty input

Use [Theory] with InlineData where it removes duplication, and name tests
Method_Scenario_Expected. Do not write the implementation.
```

**What changed:** framework named, method under test named, behaviour spelled out, cases enumerated, structure and naming requested, and scope fenced ("do not write the implementation").

---

## The pattern behind all three cards

| Ingredient | Card 1 | Card 2 | Card 3 |
|---|---|---|---|
| **Goal** | "return the most frequent words" | "count words correctly" | "write xUnit tests" |
| **Context** | signature + record | the selected code + a failing input | the signature + its behaviour |
| **Constraints** | tokenizing, ordering, no I/O | keep signature, no `Main` | listed cases, naming, no implementation |
| **Example** | — | `"Hello,  world"` → 2 | `[Theory]` / `InlineData` |

Steal this table. It is the whole of prompt engineering in one row per prompt.
