using System.Text.RegularExpressions;

namespace WordFrequency;

public static class WordFrequencyAnalyzer
{
    private const string TokenPattern = "[A-Za-z0-9]+";
    private static readonly Regex TokenRegex = new(TokenPattern, RegexOptions.CultureInvariant);

    public static IReadOnlyList<WordCount> TopWords(string text, int top)
    {
        ArgumentNullException.ThrowIfNull(text);

        if (top <= 0)
        {
            return [];
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            return [];
        }

        return CountWords(text)
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key, StringComparer.Ordinal)
            .Take(top)
            .Select(pair => new WordCount(pair.Key, pair.Value))
            .ToArray();
    }

    private static Dictionary<string, int> CountWords(string text)
    {
        var counts = new Dictionary<string, int>(StringComparer.Ordinal);

        foreach (Match match in TokenRegex.Matches(text))
        {
            var word = match.Value.ToLowerInvariant();
            counts[word] = counts.TryGetValue(word, out var currentCount) ? currentCount + 1 : 1;
        }

        return counts;
    }
}
