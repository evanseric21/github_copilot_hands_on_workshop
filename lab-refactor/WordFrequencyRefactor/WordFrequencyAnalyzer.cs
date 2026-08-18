using System.Text.RegularExpressions;

namespace WordFrequencyRefactor;

public static class WordFrequencyAnalyzer
{
    public static IReadOnlyList<WordCount> TopWords(string text, int top)
    {
        if (top <= 0)
        {
            return [];
        }

        var counts = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (Match match in Regex.Matches(text, "[A-Za-z0-9]+"))
        {
            var word = match.Value.ToLowerInvariant();
            if (counts.ContainsKey(word))
            {
                counts[word] = counts[word] + 1;
            }
            else
            {
                counts[word] = 1;
            }
        }

        var sorted = counts.ToList();
        sorted.Sort((left, right) =>
        {
            var countCompare = right.Value.CompareTo(left.Value);
            if (countCompare != 0)
            {
                return countCompare;
            }

            return StringComparer.Ordinal.Compare(left.Key, right.Key);
        });

        var answer = new List<WordCount>();
        for (var index = 0; index < sorted.Count && answer.Count < top; index++)
        {
            answer.Add(new WordCount(sorted[index].Key, sorted[index].Value));
        }

        return answer;
    }
}
