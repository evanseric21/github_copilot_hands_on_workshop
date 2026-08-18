namespace ScopedInstructionsDemo;

public static class InstructionProbe
{
    public static string WorkshopRuleSummary() =>
        "Use ASCII letter/digit tokens, invariant lowercase, no stop words, count desc, ordinal tie-break.";

    public static string FormatWordCount(string word, int count) => $"{word}: {count}";
}
