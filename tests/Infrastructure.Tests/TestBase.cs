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

        gameDay1.Matches.Add(new Match()
        {
            Home = madrid,
            Away = valencia,
            GameDay = gameDay2,
            GoalsHome = 1,
            GoalsAway = 2
        });

        gameDay1.Matches.Add(new Match()
        {
            Home = villareal,
            Away = barcelona,
            GameDay = gameDay2,
            GoalsHome = 5,
            GoalsAway = 0
        });

        GameDay gameDay3 = new GameDay()
        {
            Day = 3,
            League = league,
        };

        gameDay1.Matches.Add(new Match()
        {
            Home = valencia,
            Away = barcelona,
            GameDay = gameDay3,
            GoalsHome = 1,
            GoalsAway = 2
        });

        gameDay1.Matches.Add(new Match()
        {
            Home = madrid,
            Away = villareal,
            GameDay = gameDay3,
            GoalsHome = 5,
            GoalsAway = 0
        });

        league.GameDays?.Add(gameDay1);
        league.GameDays?.Add(gameDay2);
        league.GameDays?.Add(gameDay3);

        Context.Leagues?.Add(league);

        Context.SaveChanges();
    }
}