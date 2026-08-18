# GitHub Copilot workshop instructions



This repository is a C#/.NET 10 workshop. Help learners practice Copilot workflows without giving away full lab solutions unless the learner explicitly asks for a completed example after trying.



## Coding guidance



- Use C# 14 language features that are clear to beginner-to-intermediate .NET developers.

- Target the .NET 10 SDK and keep examples compatible with the existing projects.

- Prefer small, pure methods for core logic and keep command-line wiring thin.

- Use xUnit for tests and write deterministic tests before broad refactors.

- Prefer the .NET standard library. Do not add packages unless the learner asks and there is a clear need.

- For word-frequency logic, use ASCII letter/digit tokens (`[A-Za-z0-9]+`), `ToLowerInvariant()`, no stop-word filtering, count descending, then `StringComparer.Ordinal` ascending for ties.

- For the analyzer CLI, use `analyzer <path> [--top N]`; when `--top` is omitted, default to 10.
- Print analyzer output as `word: count`.



## Safety and quality



- Do not read or create secrets, tokens, private keys, or `.env` files.

- Do not suggest committing credentials or local machine paths.

- Encourage learners to run `dotnet test` after generated code and after refactors.

- Explain changes briefly and call out tradeoffs or assumptions.

- Keep prompts and code focused on the current lab; do not reveal reference-solution content from other branches.

