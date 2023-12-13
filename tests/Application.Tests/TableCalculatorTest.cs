using Application.Entities;
using Entities.Entities;
using Entities.Services;

namespace Application.Tests;
public class TableCalculatorTest
{
    [Fact]
    public void Should_Return_Correct_Table()
    {
        var league = GetLeague();
        var result = new TableCalculator().Get(league, league.GameDays.Count);
        Assert.NotNull(result);
        Assert.Multiple(
            () => { Assert.Equal("Madrid", result.Teams[0].Team.Code); }, 
            () => { Assert.Equal(14, result.Teams[0].Points); },
            () => { Assert.Equal(15, result.Teams[0].Goals); },
            () => { Assert.Equal(5, result.Teams[0].GoalsAgainst); },
            () => { Assert.Equal(4, result.Teams[0].Wins); },
            () => { Assert.Equal(2, result.Teams[0].Draws); },
            () => { Assert.Equal(0, result.Teams[0].Losses); },

            () => { Assert.Equal("Barcelona", result.Teams[1].Team.Code); },
            () => { Assert.Equal(10, result.Teams[1].Points); },
            () => { Assert.Equal(14, result.Teams[1].Goals); },
            () => { Assert.Equal(11, result.Teams[1].GoalsAgainst); },
            () => { Assert.Equal(3, result.Teams[1].Wins); },
            () => { Assert.Equal(1, result.Teams[1].Draws); },
            () => { Assert.Equal(2, result.Teams[1].Losses); },

            () => { Assert.Equal("Valencia", result.Teams[2].Team.Code); },
            () => { Assert.Equal(7, result.Teams[2].Points); },
            () => { Assert.Equal(9, result.Teams[2].Goals); },
            () => { Assert.Equal(9, result.Teams[2].GoalsAgainst); },
            () => { Assert.Equal(2, result.Teams[2].Wins); },
            () => { Assert.Equal(1, result.Teams[2].Draws); },
            () => { Assert.Equal(3, result.Teams[2].Losses); },

            () => { Assert.Equal("Villareal", result.Teams[3].Team.Code); },
            () => { Assert.Equal(2, result.Teams[3].Points); },
            () => { Assert.Equal(5, result.Teams[3].Goals); },
            () => { Assert.Equal(18, result.Teams[3].GoalsAgainst); },
            () => { Assert.Equal(0, result.Teams[3].Wins); },
            () => { Assert.Equal(2, result.Teams[3].Draws); },
            () => { Assert.Equal(4, result.Teams[3].Losses); }
            );
    }

    private League GetLeague()
    {
        var league = new League();
        var barcelona = new Team()
        {
            Code = "Barcelona",
        };

        var madrid = new Team
        {
            Code = "Madrid",
        };

        var valencia = new Team
        {
            Code = "Valencia",
        };

        var villareal = new Team
        {
            Code = "Villareal",
        };

        GameDay gameDay1 = new GameDay()
        {
            Day = 1,
            League = league,
        };

        gameDay1.Matches.Add(new Match()
        {
            Home = barcelona,
            Away = madrid,
            GameDay = gameDay1,
            GoalsHome = 1,  
            GoalsAway = 2   
        });

        gameDay1.Matches.Add(new Match()
        {
            Home = valencia,
            Away = villareal,
            GameDay = gameDay1,
            GoalsHome = 5,
            GoalsAway = 0
        });

        GameDay gameDay2 = new GameDay()
        {
            Day = 2,
            League = league,
        };

        gameDay2.Matches.Add(new Match()
        {
            Home = madrid,
            Away = valencia,
            GameDay = gameDay2,
            GoalsHome = 2,
            GoalsAway = 0
        });

        gameDay2.Matches.Add(new Match()
        {
            Home = villareal,
            Away = barcelona,
            GameDay = gameDay2,
            GoalsHome = 1,
            GoalsAway = 3
        });

        GameDay gameDay3 = new GameDay()
        {
            Day = 3,
            League = league,
        };

        gameDay3.Matches.Add(new Match()
        {
            Home = valencia,
            Away = barcelona,
            GameDay = gameDay3,
            GoalsHome = 0,
            GoalsAway = 3
        });

        gameDay3.Matches.Add(new Match()
        {
            Home = madrid,
            Away = villareal,
            GameDay = gameDay3,
            GoalsHome = 1,
            GoalsAway = 1
        });

        GameDay gameDay4 = new GameDay()
        {
            Day = 4,
            League = league,
        };

        gameDay4.Matches.Add(new Match()
        {
            Home = madrid,
            Away = barcelona,
            GameDay = gameDay4,
            GoalsHome = 2,
            GoalsAway = 2
        });

        gameDay4.Matches.Add(new Match()
        {
            Home = villareal,
            Away = valencia,
            GameDay = gameDay4,
            GoalsHome = 0,
            GoalsAway = 0
        });

        GameDay gameDay5 = new GameDay()
        {
            Day = 5,
            League = league,
        };

        gameDay5.Matches.Add(new Match()
        {
            Home = valencia,
            Away = madrid,
            GameDay = gameDay5,
            GoalsHome = 1,
            GoalsAway = 4
        });

        gameDay5.Matches.Add(new Match()
        {
            Home = barcelona,
            Away = villareal,
            GameDay = gameDay5,
            GoalsHome = 5,
            GoalsAway = 3
        });

        GameDay gameDay6 = new GameDay()
        {
            Day = 6,
            League = league,
        };

        gameDay6.Matches.Add(new Match()
        {
            Home = barcelona,
            Away = valencia,
            GameDay = gameDay6,
            GoalsHome = 0,
            GoalsAway = 3
        });

        gameDay6.Matches.Add(new Match()
        {
            Home = villareal,
            Away = madrid,
            GameDay = gameDay6,
            GoalsHome = 0,
            GoalsAway = 4
        });

        league.GameDays?.Add(gameDay1);
        league.GameDays?.Add(gameDay2);
        league.GameDays?.Add(gameDay3);
        league.GameDays?.Add(gameDay4);
        league.GameDays?.Add(gameDay5);
        league.GameDays?.Add(gameDay6);

        return league;
    }
}
