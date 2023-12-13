using Application.Entities;
using Entities.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests;

public abstract class TestBase
{
    protected LeagueManagerContext Context { get; set; }
    protected TestBase()
    {

        Context = new LeagueManagerContext();
        Context.Database.Migrate();
        Context.Database.EnsureCreated();
        Context.Leagues?.RemoveRange(Context.Leagues);
        Context.Teams?.RemoveRange(Context.Teams);
        var barcelona = new Team()
        {
            Code = "Barcelona",
        };
        
        var madrid = new Team {
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

        var league = new League();
        league.Teams.Add(barcelona);
        league.Teams.Add(madrid);
        league.Teams.Add(valencia);
        league.Teams.Add(villareal);
        
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

        Context.Leagues?.Add(league);

        Context.SaveChanges();
    }
}