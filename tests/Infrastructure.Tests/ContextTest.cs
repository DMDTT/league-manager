using Infrastructure.Data;

namespace Infrastructure.Tests;

public class ContextTest : TestBase
{
    [Fact]
    public void Test_Mappings()
    {
        var league = Context.Leagues.FirstOrDefault();
        Assert.Multiple(() =>
        {
            Assert.NotNull(league);
            Assert.Equal(6, league.GameDays.Count);
        });
    }
}