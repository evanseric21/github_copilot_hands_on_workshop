---
name: csharp-xunit-test
description: TODO — one or two sentences. Say WHAT this does and WHEN to use it, e.g. "Scaffold a new xUnit test class that follows this repository's C# test conventions. Use when adding tests for a C# class in this repo."
---

# New xUnit test class

> **This is a Lab 3 template, not an active skill.** It only becomes a skill once you copy it to
> `.github/skills/csharp-xunit-test/SKILL.md` and fill in every `TODO`.
> Delete this quote block when you copy the file.

Use these steps whenever someone asks for tests for a C# type in this repository.

## Steps

1. Create `<ClassName>Tests.cs` in the test project that references the project under test.
2. Use a file-scoped namespace ending in `.Tests`, and mark the class `public sealed`.
3. TODO — state the test attribute convention. (Which attribute for a single case? Which for
   table-driven cases, and what supplies the data?)
4. TODO — state the test naming convention, and give one real example name.
5. Cover, at minimum: the happy path, one boundary or empty input, and one error case.
6. Do not change production code to make a test pass. Report the failure instead.

## Example

```csharp
namespace WordFrequencyRefactor.Tests;

public sealed class WordFrequencyAnalyzerTests
{
    [Fact]
    public void TopWords_EmptyText_ReturnsEmptyList()
    {
        Assert.Empty(WordFrequencyAnalyzer.TopWords(string.Empty, 5));
    }
}
```

## Resources

- TODO (optional) — link `resources/xunit-test-class.md` here if you copy it alongside this file.
  Copilot only opens a bundled resource when a step points at it, which is what keeps skills cheap.
