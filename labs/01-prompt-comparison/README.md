# Lab 1 — Prompt comparison

⬅️ [Lab 0 — Preflight](../00-preflight/README.md)

| | |
|---|---|
| **Timebox** | 10 minutes |
| **Copilot surface** | Copilot Chat — **Ask** mode (inline chat also fine) |
| **Working directory** | Repository root — `github_copilot_hands_on_workshop`. No files need to be open. |
| **Starting point** | [`prompts/weak-prompts.md`](prompts/weak-prompts.md) — three deliberately bad prompts |
| **Track** | Core → Beginner fallback → Stretch |

## Goal

Run the **same request twice** — once vague, once specific — and see the difference with your own eyes.
By the end you should be able to say *why* the second one worked, not just that it did.

The recipe you are practising is the one from the deck:

> **Goal + Context + Constraints + (Example when it helps)**

Everything you write here is reusable: the "after" prompts in this lab are the seeds of the prompts you will use in Lab 5.

## Prerequisites

- Lab 0 passed (Copilot Chat answers you).
- Nothing to build, nothing to install. **You do not write any code in this lab.**

## Definition of done

- [ ] You ran all three **weak** prompts and skimmed the results.
- [ ] You rewrote all three with goal + context + constraints, and ran them.
- [ ] You can point at one concrete difference per pair — not "it's better", but *what* is better.
- [ ] You have one before/after pair you would be happy to read aloud.

---

## Steps

1. **Open Copilot Chat in Ask mode.** Start a *new* chat. Agent mode is not needed here and will slow you down.
2. **Open** [`prompts/weak-prompts.md`](prompts/weak-prompts.md) and read the three weak prompts. Keep it open — you will copy from it.
3. **Run weak prompt #1** (`make a function`) exactly as written. Do not add context. Skim the answer and note what Copilot had to guess: language? framework? signature? edge cases?
4. **Rewrite it.** Add a goal, the context Copilot was guessing at, and hard constraints. If you stall, take the ready-made rewrite from [`prompts/prompt-cards.md`](prompts/prompt-cards.md) — using the card is a legitimate way to finish this lab.
5. **Run your rewrite in a new chat.** A new chat matters: otherwise Copilot reuses the first answer as context and you cannot tell what your prompt actually earned.
6. **Repeat steps 3–5** for weak prompt #2 (`fix this`) and #3 (`write tests`).
7. **Pick your best pair** and write one sentence in [`comparison-worksheet.md`](comparison-worksheet.md): *the improved prompt produced X, which the weak one did not.*

## Copy/paste prompts

The full set lives in [`prompts/prompt-cards.md`](prompts/prompt-cards.md). Here is pair #1 so you can start in ten seconds.

**Weak:**

```text
make a function
```

**Strong:**

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

## Midpoint checkpoint (at 5 minutes)

You should have **finished pair #1 and be running pair #2**.

If you are still on pair #1, stop composing and use the prompt cards for #2 and #3 — the point of the lab is to *see* the contrast, not to author it from scratch.

## Verify

You are done when, for each pair, you can fill in this sentence with something specific:

> "The weak prompt made Copilot guess **\_\_\_\_**; my improved prompt removed that guess by stating **\_\_\_\_**."

Good specifics: *"guessed the test framework — I named xUnit"*, *"guessed the tie-break — I specified `StringComparer.Ordinal`"*, *"invented a `Main` — I said pure function, no I/O"*.

Vague answers ("it was longer", "it was nicer") mean the rewrite was not actually more constrained. Add one more constraint and run it again.

## No-push / no-PR fallback

Nothing in this lab touches git. You will not commit, push, or open a pull request.
[`comparison-worksheet.md`](comparison-worksheet.md) is yours to scribble in locally — leave it uncommitted if you prefer.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| Blank page — you cannot think of constraints | Use [`prompts/prompt-cards.md`](prompts/prompt-cards.md) verbatim. Run the card, then change **one word** and run it again. Editing beats authoring. |
| Both answers look basically the same | You are probably in the same chat thread. Start a new chat for every prompt. |
| Copilot writes a whole console app when you asked for a method | Add the constraint `No Main method, no Console calls, no file I/O.` That one line is the fix. |
| The C# it produced uses something you do not recognise | Fine — you are grading the *prompt*, not the code. Nothing here has to compile. |
| You ran out of time on pair #3 | Skip it. Two solid pairs beats three rushed ones, and the timer wins. |

## Stretch (optional, intermediate)

- **Pattern-stacking:** take your strongest prompt and add a *role* ("act as a C# reviewer"), then a *few-shot example* (one input line and its expected output). Which addition changed the answer more?
- **Explain-then-do:** prefix a prompt with `First explain your approach in 3 bullets, then write the code.` Catching a wrong assumption in bullets is far cheaper than catching it in a diff.
- **Refine-in-place:** instead of restarting, reply `Keep everything, but change only the tie-break to StringComparer.Ordinal.` Notice how much less you had to type.
- **Save the winner** into [`comparison-worksheet.md`](comparison-worksheet.md). You will paste it straight into Lab 5.

## Reflect (30 seconds)

Which single constraint bought the biggest improvement — naming the signature, naming the framework, or forbidding things ("no `Main`, no I/O")?
That is the constraint you are probably leaving out of your prompts at work.

## Next

➡️ [Lab 2 — Scoped C# instructions](../02-scoped-csharp-instructions/README.md)
