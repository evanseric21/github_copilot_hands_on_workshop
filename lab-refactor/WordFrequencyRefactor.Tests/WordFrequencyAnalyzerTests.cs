using WordFrequencyRefactor;

namespace WordFrequencyRefactor.Tests;

public sealed class WordFrequencyAnalyzerTests
{
    [Fact]
    public void TopWords_UsesAsciiTokensInvariantLowercaseDigitsAndOrdinalTies()
    {
        var expected = new[]
        {
            new WordCount("beta", 3),
            new WordCount("42", 2),
            new WordCount("alpha", 2)
        };

        var results = WordFrequencyAnalyzer.TopWords("Beta beta alpha ALPHA 42 42 beta", 3);

        Assert.Equal(expected, results);
    }

    [Fact]
    public void TopWords_UsesWorkshopSampleExpectedTopFive()
    {
        var expected = new[]
        {
            new WordCount("tests", 5),
            new WordCount("build", 3),
            new WordCount("code", 3),
            new WordCount("copilot", 3),
            new WordCount("practice", 3)
        };
        var text = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt"));

        var results = WordFrequencyAnalyzer.TopWords(text, 5);

        Assert.Equal(expected, results);
    }

    [Fact]
    public void TopWords_ReturnsEmptyListWhenTopIsZero()
    {
        Assert.Empty(WordFrequencyAnalyzer.TopWords("anything", 0));
    }
}
