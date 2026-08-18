# Facilitator guide



Audience: instructors and helpers running the 120-minute public workshop.



## Before learners arrive



- Open the room 15-20 minutes early for [preflight](preflight.md).

- Put clone, Wi-Fi, and sign-in reminders on screen.

- Run `dotnet test .\GitHubCopilotWorkshop.sln` on the presenter machine.

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

| 53-59 | MCP literacy/demo | 21-23 | Include the 2.5-minute guided/read-only MCP practice; inspect `.vscode/mcp.json.example`; no credentials. |

| 59-64 | Capstone A setup | 24-26 | Explain loop: prompt, generate, run, test, iterate. |

| 64-91 | Capstone A lab | 27 | Build analyzer. Use pairing and fallback prompts for blocked learners. |

| 91-97 | Refactor setup | 28-30 | Open `lab-refactor`; explain characterization tests and local review. |

| 97-116 | Capstone B lab | 31 | Refactor, request editor-local review, triage findings, rerun tests. |

| 116-120 | Wrap-up | 32-34 | Reinforce habits and point to [resources](resources.md). |



Approved lab timeboxes: Lab 1 = 10 minutes, Lab 2 = 8 minutes, Lab 3 = 8 minutes, Lab 4 = 2.5 minutes, Capstone A = 27 minutes, Capstone B = 19 minutes.

## Checkpoints and recovery thresholds



- Minute 2: at least 80% should have preflight green. If not, pair blocked learners and continue.

- Lab 1 minute 23: every pair should have one improved prompt. If not, provide a prompt frame.

- Lab 2 minute 39: learners should have an instruction file started. If not, let them copy the frontmatter shape from the slide and add one rule.

- Lab 3 minute 49: learners should have a `SKILL.md` with `name` and `description`. If not, switch to read-and-explain mode.

- Capstone A minute 75: learners should have projects scaffolded and at least one failing or passing test. If not, pair with someone green and focus on one pure method.

- Capstone A minute 86: if tests are not close, cut CLI polish and use library tests only.

- Capstone B minute 106: learners should have requested editor-local review or reviewed a selection. If not, demo on the projector and let them observe.

- Minute 116: stop coding, run tests, capture one takeaway.



## Cut order if time is tight



1. MCP hands-on becomes facilitator-only demo.

2. Lab 3 optional template resource is skipped.

3. Capstone A CLI argument polish is reduced; keep pure logic and tests.

4. Capstone B requires one review request and one finding triaged instead of two.

5. Optional pull request review is removed entirely.



Do not cut preflight, tests, or the final review habit.



## Pairing strategy



- Pair by confidence, not job title.

- One driver, one prompt navigator; switch at each lab boundary.

- Helpers ask guiding questions first: "What did Copilot assume?" and "What test proves it?"

- If a learner's machine is blocked by policy, pair them with a working machine and keep them active as prompt navigator.



## Cold-restore mitigation



- Ask learners to run `dotnet test .\GitHubCopilotWorkshop.sln` before the session.

- Keep a presenter clone with packages restored.

- If restore is slow, start learners on Lab 1 while helpers resolve package/network issues.

- If a corporate proxy blocks restore, use a paired machine; do not spend live lab time debugging proxy policy.

- Keep the sample output visible so learners can still reason about expected behavior.



## Release gates for repository updates



Before publishing a workshop update:



- `dotnet test .\GitHubCopilotWorkshop.sln` passes.

- Default branch contains no reference solutions; those stay on `reference-solutions`.

- No slide deck, secrets, private planning notes, absolute local paths, or generated `bin`/`obj` output are intentionally added.

- Documentation links validate.

- `docs/resources.md` contains all external links.

- VS Code Agent Skills, MCP, and Copilot code review wording has a last-verified date.

- A clean learner can complete core labs inside the timeboxes.

