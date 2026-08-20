# GitHub Copilot Hands-On Workshop

A public 120-minute workshop for beginner-to-intermediate .NET developers. You will use GitHub Copilot to prompt, customize, build, test, refactor, and review a small C# word-frequency analyzer.

## Start here

1. Install the tools in [docs/setup.md](docs/setup.md) before the workshop.
2. Clone this repository and open it in VS Code:

   ```bash
   # Working directory: wherever you keep code
   git clone https://github.com/evanseric21/github_copilot_hands_on_workshop.git
   cd github_copilot_hands_on_workshop
   code .
   ```

3. Let VS Code install the recommended extensions when prompted.
4. Confirm Copilot Chat is signed in and can switch to Agent mode.
5. When you arrive: → open `labs/00-preflight/README.md`.

## What you'll build

You will build and improve a C#/.NET 10 command-line word-frequency analyzer. The analyzer reads text, finds ASCII letter/digit tokens with `[A-Za-z0-9]+`, lowercases with invariant culture, counts words, sorts by count descending and `StringComparer.Ordinal` ascending for ties, and prints `word: count`. When `--top` is omitted, the default result count is 10.

The sample file is [samples/sample.txt](samples/sample.txt). With `--top 5`, the expected top words are `tests: 5`, `build: 3`, `code: 3`, `copilot: 3`, and `practice: 3`.

## Agenda

| Time | Segment | Outcome |
| --- | --- | --- |
| Before start | Lab 0 pre-roll | Tools, sign-in, restore, and test check |
| 0-2 min | Lab 0 gate | Green preflight or paired recovery |
| 2-10 min | Foundations | Copilot surfaces, modes, and context |
| 10-28 min | Prompting + Lab 1 | Better prompts and a 10-minute before/after lab |
| 28-53 min | Customization + Labs 2-3 | Scoped instructions plus a reusable skill |
| 53-59 min | Lab 4 MCP literacy | Guided, read-only trust and configuration walkthrough |
| 59-91 min | Lab 5 build analyzer | Tested C# analyzer CLI from an empty work folder |
| 91-116 min | Lab 6 refactor review | Characterization tests, refactor, editor-local review |
| 116-120 min | Wrap-up | Habits, references, and next steps |

## The 7 labs

| Lab | Minutes | What you do |
| --- | ---: | --- |
| [Lab 0 — Preflight](labs/00-preflight/) | Pre-roll + 2-minute gate | Confirm .NET 10, Copilot Chat, agent mode, and the local review entry point before the clock starts. |
| [Lab 1 — Prompt comparison](labs/01-prompt-comparison/) | 10 | Run weak prompts, rewrite them with goal/context/constraints, and compare the difference. |
| [Lab 2 — Scoped C# instructions](labs/02-scoped-csharp-instructions/) | 8 | Add a scoped `.instructions.md` file and watch Copilot apply C# conventions to a starter file. |
| [Lab 3 — Reusable C# skill](labs/03-reusable-csharp-skill/) | 8 | Create a small Agent Skill that packages this repo's xUnit test conventions. |
| [Lab 4 — MCP literacy](labs/04-mcp-literacy/) | 2.5 | Inspect a read-only MCP example and learn the trust rules without connecting anything. |
| [Lab 5 — Build analyzer](labs/05-build-analyzer/) | 27 | Use agent mode to build and test a C# word-frequency CLI from an empty work folder. |
| [Lab 6 — Refactor review](labs/06-refactor-review/) | 19 | Refactor a working analyzer, request editor-local Copilot review, and triage findings. |

## Editor support

VS Code is the primary workshop editor. The live instructions, scoped instructions, Agent Skills, MCP example, and editor-local Copilot review path are written for VS Code. Visual Studio and Rider can run the .NET projects and may provide Copilot features, but their menus may differ. See [docs/setup.md](docs/setup.md) for practical notes.

## Stuck?

Start with [docs/troubleshooting.md](docs/troubleshooting.md). If setup is the issue, use [docs/setup.md](docs/setup.md). During the live session, raise your hand after two minutes blocked so you can pair or switch tracks without losing the lab.

## For facilitators

Facilitators should use [docs/facilitator-guide.md](docs/facilitator-guide.md). Keep facilitator recovery paths out of the learner quickstart unless the room needs them.
