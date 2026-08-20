# Facilitator guide

Audience: instructors and helpers running the 120-minute public workshop.

## Before learners arrive

- Open the room 15-20 minutes early for [Lab 0 preflight](../labs/00-preflight/README.md).
- Put clone, Wi-Fi, and sign-in reminders on screen.
- Run `dotnet test GitHubCopilotWorkshop.sln` on the presenter machine.
- Keep a clean clone ready for projection.
- Keep the slide deck separate from the repository.
- Remind helpers: do not type complete solutions for learners.

## Minute-by-minute run of show

| Time | Segment | Slides | Facilitation notes |
| --- | --- | --- | --- |
| T-20-0 | Doors-open preflight | none | Clone, sign in, restore, run preflight. Pair anyone blocked by policy. |
| 0-2 | In-session gate | 1-2 | Ask for green preflight. Anyone not green pairs or observes while helper recovers. |
| 2-10 | Foundations | 3-8 | Calibrate room; explain surfaces, modes, context. |
| 10-18 | Prompting concepts | 9-12 | Show weak vs strong prompt. |
| 18-28 | Lab 1 | 13 | Learners rewrite prompts and compare output. |
| 28-35 | Repo instructions | 14-17 | Explain `.github/copilot-instructions.md` and scoped instructions. |
| 35-43 | Lab 2 | 17 | Author scoped C# instructions against the provided starter file. |
| 43-45 | Skills concept | 18-19 | Show `SKILL.md` shape, not internal examples. |
| 45-53 | Lab 3 | 20 | Create a simple skill; skip scripts unless learners are ahead. |
| 53-59 | Lab 4 MCP literacy/demo | 21-23 | Include the 2.5-minute guided/read-only practice; inspect `.vscode/mcp.json.example`; no credentials. |
| 59-64 | Lab 5 setup | 24-26 | Explain loop: prompt, generate, run, test, iterate. |
| 64-91 | Lab 5 build analyzer | 27 | Build analyzer. Use pairing and fallback prompts for blocked learners. |
| 91-97 | Lab 6 setup | 28-30 | Open `labs/06-refactor-review/starter/`; explain characterization tests and local review. |
| 97-116 | Lab 6 refactor review | 31 | Refactor, request editor-local review, triage findings, rerun tests. |
| 116-120 | Wrap-up | 32-34 | Reinforce habits and point to [reference](reference.md). |

Approved lab timeboxes: Lab 0 pre-roll gate = 2 minutes, Lab 1 = 10 minutes, Lab 2 = 8 minutes, Lab 3 = 8 minutes, Lab 4 = 2.5 minutes, Lab 5 = 27 minutes, Lab 6 = 19 minutes.

## Checkpoints and recovery thresholds

- Minute 2: at least 80% should have preflight green. If not, pair blocked learners and continue.
- Lab 1 minute 23: every pair should have one improved prompt. If not, provide a prompt frame.
- Lab 2 minute 39: learners should have an instruction file started. If not, let them copy the README block and add one rule.
- Lab 3 minute 49: learners should have a `SKILL.md` with `name` and `description`. If not, switch to the finished fallback skill.
- Lab 5 minute 75: learners should have projects scaffolded and at least one test run. If not, pair with someone green and focus on one pure method.
- Lab 5 minute 86: if tests are not close, cut CLI polish and use library tests only.
- Lab 6 minute 106: learners should have requested editor-local review or reviewed a selection. If not, demo on the projector and let them observe.
- Minute 116: stop coding, run tests, capture one takeaway.

## Cut order if time is tight

1. Lab 4 hands-on becomes facilitator-only demo.
2. Lab 3 optional template resource is skipped.
3. Lab 5 CLI argument polish is reduced; keep pure logic and tests.
4. Lab 6 requires one review request and one finding triaged instead of two.
5. Optional pull request review is removed entirely.

Do not cut preflight, tests, or the final review habit.

## Pairing strategy

- Pair by confidence, not job title.
- One driver, one prompt navigator; switch at each lab boundary.
- Helpers ask guiding questions first: "What did Copilot assume?" and "What test proves it?"
- If a learner's machine is blocked by policy, pair them with a working machine and keep them active as prompt navigator.

## Cold-restore mitigation

- Ask learners to run `dotnet test GitHubCopilotWorkshop.sln` before the session.
- Keep a presenter clone with packages restored.
- If restore is slow, start learners on Lab 1 while helpers resolve package/network issues.
- If a corporate proxy blocks restore, use a paired machine; do not spend live lab time debugging proxy policy.
- Keep the sample output visible so learners can still reason about expected behavior.

## Accessibility

The workshop should be usable by learners with different devices, abilities, and experience levels.

Facilitator practices:

- Share materials before the session when possible.
- Speak prompts aloud and paste them into chat or slides.
- Use large font sizes in the editor and terminal.
- Describe visual changes, not just "as you can see."
- Leave time for screen readers and keyboard navigation.
- Offer pairing without calling out why someone needs it.
- Keep breaks and timeboxes visible.

Learner options:

- Pair as driver/navigator if typing or setup is hard.
- Use VS Code keyboard shortcuts, zoom, high contrast, or screen reader support.
- Ask for prompts or commands to be repeated in text.
- Observe the MCP demo instead of configuring anything locally.
- Complete editor-local review without pushing code.

Documentation style:

- Use descriptive link text.
- Keep commands in copyable code blocks.
- Avoid relying on color alone.
- Define terms in [reference.md](reference.md).
- Keep external references centralized in [reference.md](reference.md).

## Release gates for repository updates

Before publishing a workshop update:

- `dotnet test GitHubCopilotWorkshop.sln` passes.
- Default branch contains no reference solutions; those stay on `reference-solutions`.
- No slide deck, secrets, private planning notes, absolute local paths, or generated `bin`/`obj` output are intentionally added.
- Documentation links validate.
- [reference.md](reference.md) contains all external links.
- VS Code Agent Skills, MCP, and Copilot code review wording has a last-verified date.
- A clean learner can complete core labs inside the timeboxes.
