# Lab 1 — the three weak prompts

Copy these **exactly as written**. Do not fix them, do not add context — that is the whole point.
Run each one in a **new** Copilot Chat thread, skim the answer, then move to the matching card in [`prompt-cards.md`](prompt-cards.md).

---

## Weak prompt #1

```text
make a function
```

**Watch for:** Copilot has to guess the language, the signature, the return type, and what the function is even for. Whatever it produces, you did not ask for it.

---

## Weak prompt #2

Select this snippet in an editor tab first (or paste it into chat), then send the weak prompt.

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

**Watch for:** "fix" is undefined. Fix what — a crash? Performance? Style? Copilot will pick a problem for you, and it may not be yours. The real bug here is that punctuation and double spaces make the count wrong, and Copilot has no way to know that is what you care about.

---

## Weak prompt #3

```text
write tests
```

**Watch for:** no framework, no method under test, no cases. You will get plausible tests for imaginary code.

---

## Now improve them

Rewrite each with **goal + context + constraints (+ example when it helps)**.

Stuck? Every rewrite is already written for you in [`prompt-cards.md`](prompt-cards.md). Run the card, then change one thing and run it again.
