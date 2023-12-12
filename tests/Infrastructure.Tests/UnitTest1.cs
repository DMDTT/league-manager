using Infrastructure.Data;

namespace Infrastructure.Tests;

public class UnitTest1 : TestBase
{
    [Fact]
    public void ContextTest()
    {
        var league = Context.Leagues.FirstOrDefault();
        Assert.Multiple(() =>
        {
            Assert.NotNull(league);
            Assert.Equal(3, league.GameDays.Count);
        });
    }
}