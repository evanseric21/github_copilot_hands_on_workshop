using WordFrequencyRefactor;

namespace WordFrequencyRefactor.Tests;

public sealed class CommandLineAppTests
{
    [Fact]
    public void Run_PrintsHelpWithSuccessExitCode()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = CommandLineApp.Run(["--help"], output, error);

        Assert.Equal(0, exitCode);
        Assert.Contains("Usage: analyzer <path> [--top N]", output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }

    [Fact]
    public void Run_ReturnsArgumentErrorForBadTop()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath, "--top", "zero"], output, error);

        Assert.Equal(2, exitCode);
        Assert.Contains("--top", error.ToString());
    }

    [Fact]
    public void Run_ReturnsFileErrorForMissingPath()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = CommandLineApp.Run(["missing-file.txt"], output, error);

        Assert.Equal(1, exitCode);
        Assert.Contains("File not found", error.ToString());
    }

    [Fact]
    public void Run_PrintsDefaultTopTenWords()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();
        var samplePath = Path.Combine(AppContext.BaseDirectory, "samples", "sample.txt");

        var exitCode = CommandLineApp.Run([samplePath], output, error);

        Assert.Equal(0, exitCode);
        var expected = string.Join(Environment.NewLine,
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
        Assert.Equal(expected, output.ToString());
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
        var expected = string.Join(Environment.NewLine,
            "tests: 5",
            "build: 3",
            "code: 3",
            "copilot: 3",
            "practice: 3") + Environment.NewLine;
        Assert.Equal(expected, output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }
}
