# Lab 1 — Prompt comparison
> Lab 1 of 7 · [⬅️ Previous](../00-preflight/README.md) · [🏠 Workshop home](../../README.md)

| | |
| --- | --- |
| **Timebox** | 10 minutes |
| **Copilot surface** | Copilot Chat — Ask mode |
| **Working directory** | Repository root — only `comparison-worksheet.md` is edited |
| **Starting point** | The weak and strong prompts below |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Run the same request twice — once vague, once specific — and see the difference. Practice **Goal + Context + Constraints + Example when it helps**.

## Before you start

Lab 0 passed and Copilot Chat answers you. You do not write code in this lab; you compare prompt quality and record one before/after observation in [comparison-worksheet.md](comparison-worksheet.md).

## Steps

1. Open Copilot Chat in Ask mode and start a new chat.

2. Run weak prompt 1 exactly as written.

   Expect something generic and unpredictable here — the weak prompt forces Copilot to guess, and that's exactly the point. You'll fix it with a stronger prompt next.

   ```text
   make a function
   ```

3. Run strong prompt 1 in a new chat.

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

4. Paste this snippet into Copilot Chat, then run weak prompt 2.

   ```csharp
   public static int CountWords(string text)
   {
       var parts = text.Split(' ');
       return parts.Length;
   }
   ```

   ```text
   fix this
   ```

5. Run strong prompt 2 in a new chat.

   ```text
   This C# method is supposed to count how many words are in a string, but it is wrong.

   Current behavior: "Hello,  world" returns 3 because it splits on a single space and
   counts the empty string, and "word." is treated as a different word from "word".

   Expected behavior: count the number of tokens matching the regex [A-Za-z0-9]+,
   so "Hello,  world" returns 2.

   Constraints:
   - Keep the method name and the public static signature.
   - Do not add a Main method or Console output.
   - Explain the root cause in one sentence before you show the fixed code.
   ```

6. Run weak prompt 3 in a new chat.

   ```text
   write tests
   ```

7. Run strong prompt 3 in a new chat.

   ```text
   Write xUnit tests in C# for this method:

       public static IReadOnlyList<WordCount> TopWords(string text, int top)

   Behavior under test:
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

8. Write one sentence in [comparison-worksheet.md](comparison-worksheet.md): the improved prompt produced X, which the weak one did not.

## Done when

- [ ] You ran all three weak prompts and skimmed the results.
- [ ] You ran all three improved prompts in fresh chats.
- [ ] You can point at one concrete difference per pair.
- [ ] You wrote one before/after observation in `comparison-worksheet.md`.

## Verify

For each pair, fill in this sentence with specifics:

```text
The weak prompt made Copilot guess ______; my improved prompt removed that guess by stating ______.
```

## If you get stuck

<details>
<summary>Fallback path</summary>

At 5 minutes you should have finished pair 1 and be running pair 2. If not, stop composing from scratch and use the strong prompts above.

| Symptom | Fix |
| --- | --- |
| Both answers look the same | Start a new chat for every prompt. |
| Copilot writes a console app | Add: `No Main method, no Console calls, no file I/O.` |
| The C# uses unfamiliar APIs | Fine; you are grading the prompt, not compiling code. |
| Out of time on pair 3 | Two solid pairs beat three rushed ones. |

Nothing in this lab touches git. For more help, see [docs/troubleshooting.md](../../docs/troubleshooting.md).

</details>

## Stretch

<details>
<summary>Optional prompt experiments</summary>

- Add a role, then add a few-shot example. Which changed the answer more?
- Prefix a prompt with `First explain your approach in 3 bullets, then write the code.`
- Refine in place with `Keep everything, but change only the tie-break to StringComparer.Ordinal.`
- Save your best prompt in [comparison-worksheet.md](comparison-worksheet.md) for Lab 5.

</details>

## Next

➡️ [Lab 2 — Scoped C# instructions](../02-scoped-csharp-instructions/README.md)
