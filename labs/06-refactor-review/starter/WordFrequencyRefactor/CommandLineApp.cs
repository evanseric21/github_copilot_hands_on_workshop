namespace WordFrequencyRefactor;

public static class CommandLineApp
{
    private const int SuccessExitCode = 0;
    private const int FileErrorExitCode = 1;
    private const int ArgumentErrorExitCode = 2;
    private const int DefaultTop = 10;
    private const string Usage = "Usage: analyzer <path> [--top N]";

    public static int Run(string[] args, TextWriter output, TextWriter error)
    {
        if (IsHelpRequest(args))
        {
            output.WriteLine(Usage);
            return SuccessExitCode;
        }

        if (!TryParseArguments(args, error, out var command))
        {
            return ArgumentErrorExitCode;
        }

        if (!TryReadText(command.Path, error, out var text))
        {
            return FileErrorExitCode;
        }

        WriteResults(WordFrequencyAnalyzer.TopWords(text, command.Top), output);
        return SuccessExitCode;
    }

    private static bool IsHelpRequest(string[] args) =>
        args.Length == 1 && (args[0] == "--help" || args[0] == "-h");

    private static bool TryParseArguments(string[] args, TextWriter error, out AnalyzerCommand command)
    {
        command = new AnalyzerCommand(string.Empty, DefaultTop);

        if (args.Length == 0)
        {
            error.WriteLine("Missing path.");
            error.WriteLine(Usage);
            return false;
        }

        var top = DefaultTop;
        var argumentIndex = 1;
        while (argumentIndex < args.Length)
        {
            if (args[argumentIndex] != "--top")
            {
                error.WriteLine($"Unknown argument: {args[argumentIndex]}");
                return false;
            }

            if (argumentIndex + 1 >= args.Length || !int.TryParse(args[argumentIndex + 1], out top) || top <= 0)
            {
                error.WriteLine("--top must be followed by a positive whole number.");
                return false;
            }

            argumentIndex += 2;
        }

        command = new AnalyzerCommand(args[0], top);
        return true;
    }

    private static bool TryReadText(string path, TextWriter error, out string text)
    {
        text = string.Empty;

        if (!File.Exists(path))
        {
            error.WriteLine($"File not found: {path}");
            return false;
        }

        try
        {
            text = File.ReadAllText(path);
            return true;
        }
        catch (IOException ex)
        {
            error.WriteLine(ex.Message);
            return false;
        }
        catch (UnauthorizedAccessException ex)
        {
            error.WriteLine(ex.Message);
            return false;
        }
    }

    private static void WriteResults(IEnumerable<WordCount> words, TextWriter output)
    {
        foreach (var word in words)
        {
            output.WriteLine($"{word.Word}: {word.Count}");
        }
    }

    private sealed record AnalyzerCommand(string Path, int Top);
}
