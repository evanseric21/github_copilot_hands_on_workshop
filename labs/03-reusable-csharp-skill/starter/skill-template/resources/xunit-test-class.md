# Bundled resource — xUnit test class shape

This file is an **optional** resource you can bundle with your skill in Lab 3.
It exists to demonstrate progressive disclosure: Copilot loads it only when a step in `SKILL.md` points at it.

Copy it next to your `SKILL.md` if you want to try that. In VS Code Explorer, create a `resources` folder next to your skill's `SKILL.md`, then copy this file into it.

```text
# Working directory: repository root
code .github/skills/csharp-xunit-test/resources/xunit-test-class.md
```

---

## Shape of a test class in this repository

```csharp
using WordFrequencyRefactor;

namespace WordFrequencyRefactor.Tests;

public sealed class WordFrequencyAnalyzerTests
{
    [Fact]
    public void TopWords_TopIsZero_ReturnsEmptyList()
    {
        Assert.Empty(WordFrequencyAnalyzer.TopWords("anything", 0));
    }

    [Theory]
    [InlineData("Beta beta", "beta", 2)]
    [InlineData("word. word", "word", 2)]
    public void TopWords_NormalisesTokens_CountsCombine(string text, string expectedWord, int expectedCount)
    {
        var results = WordFrequencyAnalyzer.TopWords(text, 1);

        Assert.Equal(expectedWord, results[0].Word);
        Assert.Equal(expectedCount, results[0].Count);
    }
}
```

## Conventions shown above

- One test class per type under test, named `<TypeName>Tests`, `public sealed`.
- File-scoped namespace matching the test project.
- `[Fact]` for a single case; `[Theory]` + `[InlineData]` when the same assertion runs over several inputs.
- Test names read `Method_Scenario_Expected`.
- Arrange/act/assert with no shared mutable state between tests.

## Test project wiring (for reference)

The test projects in this repository target `net10.0` and reference `xunit.v3`, `xunit.runner.visualstudio`
and `Microsoft.NET.Test.Sdk`, plus a `ProjectReference` to the project under test. See
`labs/06-refactor-review/starter/WordFrequencyRefactor.Tests/WordFrequencyRefactor.Tests.csproj` for a working example.
