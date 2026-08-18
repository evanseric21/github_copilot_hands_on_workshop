using WordFrequency;

namespace WordFrequency.Tests;

public sealed class CommandLineAppTests
{
    [Fact]
    public void Run_PrintsHelpWithSuccessExitCode()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = CommandLineApp.Run(["--help"], output, error);

        Assert.Equal(0, exitCode);
        Assert.Equal($"Usage: analyzer <path> [--top N]{Environment.NewLine}", output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }

    [Fact]
    public void Run_ReturnsArgumentErrorForMissingPath()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = CommandLineApp.Run([], output, error);

        Assert.Equal(2, exitCode);
        Assert.Equal(string.Empty, output.ToString());
        Assert.Contains("Missing path.", error.ToString());
        Assert.Contains("Usage: analyzer <path> [--top N]", error.ToString());
    }

    [Fact]
    public void Run_ReturnsArgumentErrorForUnknownArgument()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath, "--skip"], output, error);

        Assert.Equal(2, exitCode);
        Assert.Equal(string.Empty, output.ToString());
        Assert.Contains("Unknown argument: --skip", error.ToString());
    }

    [Fact]
    public void Run_ReturnsArgumentErrorForBadTop()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath, "--top", "0"], output, error);

        Assert.Equal(2, exitCode);
        Assert.Equal(string.Empty, output.ToString());
        Assert.Contains("--top", error.ToString());
    }

    [Fact]
    public void Run_ReturnsFileErrorForMissingFile()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = CommandLineApp.Run(["missing-file.txt"], output, error);

        Assert.Equal(1, exitCode);
        Assert.Equal(string.Empty, output.ToString());
        Assert.Contains("File not found: missing-file.txt", error.ToString());
    }

    [Fact]
    public void Run_PrintsDefaultTopTenWords()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath], output, error);

        Assert.Equal(0, exitCode);
        Assert.Equal(ExpectedDefaultTopTen(), output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }

    [Fact]
    public void Run_PrintsExplicitTopFiveWords()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath, "--top", "5"], output, error);

        Assert.Equal(0, exitCode);
        Assert.Equal(ExpectedTopFive(), output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }

    private static string ExpectedDefaultTopTen() => string.Join(Environment.NewLine,
        "tests: 5",
        "build: 3",
        "code: 3",
        "copilot: 3",
        "practice: 3",
        "review: 3",
        "and: 2",
        "lab: 2",
        "proves: 2",
        "the: 2") + Environment.NewLine;

    private static string ExpectedTopFive() => string.Join(Environment.NewLine,
        "tests: 5",
        "build: 3",
        "code: 3",
        "copilot: 3",
        "practice: 3") + Environment.NewLine;
}
