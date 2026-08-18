using Preflight;

namespace Preflight.Tests;

public sealed class PreflightCheckTests
{
    [Fact]
    public void PreflightCheck_ReturnsGreenSignal()
    {
        Assert.True(PreflightCheck.IsReady());
        Assert.Equal(".NET 10 preflight passed", PreflightCheck.SuccessMessage);
    }
}
