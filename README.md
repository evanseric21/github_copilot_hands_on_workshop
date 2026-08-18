# GitHub Copilot Hands-On Workshop



A public 120-minute workshop for beginner-to-intermediate .NET developers. You will use GitHub Copilot to prompt, customize, build, test, refactor, and review a small C# word-frequency analyzer.



## Start in five minutes



1. Install the prerequisites in [docs/prerequisites.md](docs/prerequisites.md).

2. Clone this repository and open it in VS Code:



   ```powershell

   git clone <repository-url>

   cd github_copilot_hands_on_workshop

   code .

   ```



3. Run the preflight check:



   ```powershell

   dotnet test .\labs\00-preflight\starter\Preflight.Tests\Preflight.Tests.csproj

   ```



4. If preflight fails, use [docs/troubleshooting.md](docs/troubleshooting.md) before starting the labs.



## What you will build



You will build and improve a C#/.NET 10 command-line word-frequency analyzer. The analyzer reads text, finds ASCII letter/digit tokens with `[A-Za-z0-9]+`, lowercases with invariant culture, counts words, sorts by count descending and `StringComparer.Ordinal` ascending for ties, and prints `word: count`. When `--top` is omitted, the default result count is 10.



The sample file is [samples/sample.txt](samples/sample.txt). With `--top 5`, the expected top words are `tests: 5`, `build: 3`, `code: 3`, `copilot: 3`, and `practice: 3`.



## Learning objectives



By the end, you can:



- Prompt Copilot with goals, context, constraints, and examples.

- Use repository and scoped instruction files without overloading prompts.

- Explain what Agent Skills are and create a small learner-owned skill.

- Describe MCP at a safe literacy level and inspect a read-only VS Code example.

- Build tested C#/.NET 10 code with Copilot agent mode.

- Use editor-local Copilot code review as a first-pass review.

- Keep AI-assisted work deterministic, tested, and secret-free.



## Agenda



| Time | Segment | Outcome |

| --- | --- | --- |

| Before start | [Preflight](docs/preflight.md) | Tools, sign-in, restore, and test check |

| 0-10 min | Foundations | Copilot surfaces, modes, and context |

| 10-28 min | Prompt engineering + Lab 1 | Better prompts and 10-minute before/after lab |

| 28-53 min | Customization + Labs 2-3 | Instructions plus two 8-minute labs |

| 53-59 min | MCP guided literacy | Optional/read-only path with 2.5-minute guided demo |

| 59-91 min | Capstone A | 27-minute analyzer build lab with tests |

| 91-116 min | Capstone B | 19-minute refactor and review lab |

| 116-120 min | Wrap-up | Habits, resources, and next steps |



## Six labs in order



1. [Lab 1 — Prompt engineering](#lab-1-prompt-engineering) — 10 minutes

2. [Lab 2 — Scoped C# instructions](#lab-2-scoped-c-instructions) — 8 minutes

3. [Lab 3 — Agent Skill literacy](#lab-3-agent-skill-literacy) — 8 minutes

4. [Lab 4 — MCP guided demo](#lab-4-mcp-guided-demo) — 2.5 minutes

5. [Capstone A — Build the analyzer](#capstone-a-build-the-analyzer) — 27 minutes

6. [Capstone B — Refactor and review](#capstone-b-refactor-and-review) — 19 minutes



<a id="lab-1-prompt-engineering"></a>

### Lab 1 — Prompt engineering



No files are required. Rewrite weak prompts into clear prompts with goal, context, constraints, and an example. Compare Copilot's weak and improved outputs.



<a id="lab-2-scoped-c-instructions"></a>

### Lab 2 — Scoped C# instructions



Use the existing starter file in [labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo](labs/02-scoped-csharp-instructions/starter/ScopedInstructionsDemo). Create your own `.github/instructions/csharp.instructions.md`, then confirm Copilot follows your C# conventions.



<a id="lab-3-agent-skill-literacy"></a>

### Lab 3 — Agent Skill literacy



Create a small skill under `.github/skills/<your-skill-name>/SKILL.md`. Keep it safe and simple: instructions, optional template resource, and no secrets. This lab is about packaging a reusable workflow, not solving the analyzer.



<a id="lab-4-mcp-guided-demo"></a>

### Lab 4 — MCP guided demo



MCP is optional, read-only, and facilitator-guided. Inspect [.vscode/mcp.json.example](.vscode/mcp.json.example) only if instructed. Do not add credentials or start untrusted MCP servers.



<a id="capstone-a-build-the-analyzer"></a>

### Capstone A — Build the analyzer



Use Copilot agent mode to scaffold a console app and xUnit tests, including `analyzer <path> [--top N]` with default 10 when `--top` is omitted. Iterate with `dotnet test` until green. Remote push and pull requests are not required.



<a id="capstone-b-refactor-and-review"></a>

### Capstone B — Refactor and review



Open [lab-refactor](lab-refactor), lock behavior with tests, refactor in small steps, and request editor-local Copilot code review. Pull request review is optional enrichment.



## Expected repository layout



```text

.github/                         Learner-facing Copilot instructions and CI

.vscode/                         Recommended extensions and optional MCP example

labs/00-preflight/starter/       Tooling readiness project

labs/02-scoped-csharp-instructions/starter/

                                 Small C# file for scoped-instruction practice

lab-refactor/                    Working but refactor-ready analyzer and tests

samples/                         Original workshop sample text and expectations

docs/                            Setup, facilitation, accessibility, glossary, resources

GitHubCopilotWorkshop.sln        Solution covering provided .NET projects

```



Reference solutions live on the separate `reference-solutions` branch and are not in the default learner tree. The slide deck is distributed separately and is not included in this repository.



## Editor support



VS Code is the primary workshop editor. Visual Studio and Rider can run the .NET code and may provide Copilot features, but the live instructions, MCP example, and editor-local review path are written for VS Code. See [docs/prerequisites.md](docs/prerequisites.md) for practical notes.



## Help path



1. Run [docs/preflight.md](docs/preflight.md).

2. Check [docs/troubleshooting.md](docs/troubleshooting.md).

3. Pair with a neighbor or helper.

4. Use the facilitator recovery path in [docs/facilitator-guide.md](docs/facilitator-guide.md).



Facilitators should start with [docs/facilitator-guide.md](docs/facilitator-guide.md). Official links are centralized in [docs/resources.md](docs/resources.md).

