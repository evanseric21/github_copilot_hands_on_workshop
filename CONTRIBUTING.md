# Contributing

Thanks for improving the workshop. Keep contributions learner-facing, concise, and safe for a public classroom.

## Scope

Good contributions include:

- Clearer setup, lab, or troubleshooting guidance.
- Small C#/.NET 10 fixes that preserve deterministic behavior.
- xUnit tests that document expected behavior.
- Accessibility and facilitator improvements.

Do not add slide decks, credentials, private notes, internal planning files, or generated build output.

## Development checklist

Before opening a pull request:

1. Run the preflight test:

   ```powershell
   dotnet test .\labs\00-preflight\starter\Preflight.Tests\Preflight.Tests.csproj
   ```

2. Run the refactor lab tests if you touched C# code:

   ```powershell
   dotnet test .\lab-refactor\WordFrequencyRefactor.Tests\WordFrequencyRefactor.Tests.csproj
   ```

3. Update related docs in the same change.
4. Confirm links are relative unless they belong in `docs/resources.md`.
5. Confirm no secrets, absolute local paths, or reference solutions were added to the default branch.

## Pull requests

Pull requests are welcome for repository maintenance. Workshop learners do not need to push or create a pull request to complete the exercises.
