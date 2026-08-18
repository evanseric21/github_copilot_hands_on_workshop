using WordFrequency;

namespace WordFrequency.Tests;

public sealed class WordFrequencyAnalyzerTests
{
    [Fact]
    public void TopWords_NullText_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => WordFrequencyAnalyzer.TopWords(null!, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void TopWords_TopIsZeroOrNegative_ReturnsEmpty(int top)
    {
        Assert.Empty(WordFrequencyAnalyzer.TopWords("anything anything else", top));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   \t\r\n  ")]
    public void TopWords_EmptyOrWhitespaceInput_ReturnsEmpty(string text)
    {
        Assert.Empty(WordFrequencyAnalyzer.TopWords(text, 5));
    }

    [Fact]
    public void TopWords_NormalizesCaseWithInvariantLowercase()
    {
        var results = WordFrequencyAnalyzer.TopWords("Code CODE code", 1);

        Assert.Equal([new WordCount("code", 3)], results);
    }

    [Fact]
    public void TopWords_SplitsOnPunctuationApostrophesAndHyphens()
    {
        var expected = new[]
        {
            new WordCount("art", 1),
            new WordCount("don", 1),
            new WordCount("hello", 1),
            new WordCount("of", 1),
            new WordCount("state", 1),
            new WordCount("t", 1),
            new WordCount("the", 1),
            new WordCount("world", 1)
        };

        var results = WordFrequencyAnalyzer.TopWords("Hello, world! don't state-of-the-art", 8);

        Assert.Equal(expected, results);
    }

    [Fact]
    public void TopWords_LimitsResultsToTopCount()
    {
        var results = WordFrequencyAnalyzer.TopWords("beta beta alpha alpha alpha gamma", 2);

        Assert.Equal([new WordCount("alpha", 3), new WordCount("beta", 2)], results);
    }

    [Fact]
    public void TopWords_OrdersTiesByOrdinalWordAscending()
    {
        var results = WordFrequencyAnalyzer.TopWords("beta alpha 42", 3);

        Assert.Equal([new WordCount("42", 1), new WordCount("alpha", 1), new WordCount("beta", 1)], results);
    }

    [Fact]
    public void TopWords_IncludesDigitsAsWords()
    {
        var results = WordFrequencyAnalyzer.TopWords("42 tests 42 007", 3);

        Assert.Equal([new WordCount("42", 2), new WordCount("007", 1), new WordCount("tests", 1)], results);
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
}
