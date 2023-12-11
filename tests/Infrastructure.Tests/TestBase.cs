using Entities.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests;

public abstract class TestBase
{
    protected TestBase()
    {
        var context = new LeagueManagerContext();
        context.Database.Migrate();
        context.Database.EnsureCreated();
        var team1 = new Team()
        {
            Code = "Team1",
        };
        
        var team2 = new Team {
            Code = "Team2",
        };
            
        var league = new League();
        league.Teams.Add(team1);
        league.Teams.Add(team2);
        context.Leagues.Add(league);
        bool hasChanges = context.ChangeTracker.HasChanges();
        context.SaveChanges();
    }
}