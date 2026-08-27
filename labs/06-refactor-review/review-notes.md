# Lab 6 — review notes

Record **at least two** findings from your Copilot code review. This file is the deliverable for the
triage half of the lab — the code change alone does not count.

For each finding pick one verdict:

- **Addressed** — you agreed and changed the code. Say what you changed.
- **Dismissed** — you disagreed. Say **why**. A dismissal with a solid reason is a professional
  outcome, not a cop-out. Copilot advises; you decide.

Nobody grades this. Keep it local if you like — nothing here has to be committed or pushed.

---

## Baseline (fill in before refactoring)

- Tests passing **before** any change: `_____ / 8` (expected: 8 of 8)
- Output of `dotnet run --project labs/06-refactor-review/starter/WordFrequencyRefactor -- samples/sample.txt`
  printed 10 lines (the default `--top`): ☐ yes ☐ no
- Output of the same command with `--top 5` matched the pinned five lines: ☐ yes ☐ no

If either line above is not clean, fix it before you refactor. You cannot preserve behaviour you never measured.

---

## Finding 1

- **Where:** `labs/06-refactor-review/starter/WordFrequencyRefactor/______.cs`, around line ___
- **Severity as reported:** high / medium / low
- **What the reviewer said** (one sentence):
- **Verdict:** ☐ Addressed ☐ Dismissed
- **What I did / why I disagreed:**
- **Behaviour changed?** ☐ no (structure only) ☐ yes — and here is why that is acceptable:

## Finding 2

- **Where:** `labs/06-refactor-review/starter/WordFrequencyRefactor/______.cs`, around line ___
- **Severity as reported:** high / medium / low
- **What the reviewer said** (one sentence):
- **Verdict:** ☐ Addressed ☐ Dismissed
- **What I did / why I disagreed:**
- **Behaviour changed?** ☐ no (structure only) ☐ yes — and here is why that is acceptable:

## Finding 3 (optional)

- **Where:**
- **Severity as reported:**
- **What the reviewer said:**
- **Verdict:** ☐ Addressed ☐ Dismissed
- **What I did / why I disagreed:**

---

## After the refactor

- Tests passing **after** all changes: `_____` (must be ≥ your baseline; no test deleted or weakened)
- Default run still prints 10 lines, and `--top 5` still prints exactly `tests: 5` / `build: 3` / `code: 3` / `copilot: 3` / `practice: 3`: ☐ yes ☐ no
- Missing file still exits `1`: ☐ yes ☐ no

---

## Examples of a good dismissal

> *"Suggested switching the dictionary to `StringComparer.OrdinalIgnoreCase`. Dismissed: tokens are
> already lowercased with `ToLowerInvariant()`, so case-insensitive keys add no value and would hide a
> future tokenizer regression."*

> *"Suggested catching `Exception` around the file read. Dismissed: the contract only defines exit code 1
> for file problems; swallowing every exception would mask real bugs and is broader than the requirement."*

> *"Suggested extracting the usage string into a resource file for localisation. Dismissed: no
> localisation requirement, and the tests assert the exact English string."*

Notice the shape of each one: **what was suggested → the decision → the reason, tied to a requirement.**
That is exactly how you should answer the same question in a real pull request.
