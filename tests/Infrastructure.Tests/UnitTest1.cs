using Infrastructure.Data;

namespace Infrastructure.Tests;

public class UnitTest1 : TestBase
{
    [Fact]
    public void Test1()
    {
        Assert.True(new LeagueManagerContext().Leagues.Where(x => x.Id > 0).Count() > 0);
    }
}