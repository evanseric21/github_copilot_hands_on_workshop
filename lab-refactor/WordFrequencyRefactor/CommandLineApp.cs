namespace WordFrequencyRefactor;

public static class CommandLineApp
{
    public static int Run(string[] args, TextWriter output, TextWriter error)
    {
        if (args.Length == 1 && (args[0] == "--help" || args[0] == "-h"))
        {
            output.WriteLine("Usage: analyzer <path> [--top N]");
            return 0;
        }

        if (args.Length == 0)
        {
            error.WriteLine("Missing path.");
            error.WriteLine("Usage: analyzer <path> [--top N]");
            return 2;
        }

        var path = args[0];
        var top = 10;

        var index = 1;
        while (index < args.Length)
        {
            if (args[index] != "--top")
            {
                error.WriteLine($"Unknown argument: {args[index]}");
                return 2;
            }

            if (index + 1 >= args.Length || !int.TryParse(args[index + 1], out top) || top <= 0)
            {
                error.WriteLine("--top must be followed by a positive whole number.");
                return 2;
            }

            index += 2;
        }

        if (!File.Exists(path))
        {
            error.WriteLine($"File not found: {path}");
            return 1;
        }

        string text;
        try
        {
            text = File.ReadAllText(path);
        }
        catch (IOException ex)
        {
            error.WriteLine(ex.Message);
            return 1;
        }
        catch (UnauthorizedAccessException ex)
        {
            error.WriteLine(ex.Message);
            return 1;
        }

        foreach (var word in WordFrequencyAnalyzer.TopWords(text, top))
        {
            output.WriteLine($"{word.Word}: {word.Count}");
        }

        return 0;
    }
}
