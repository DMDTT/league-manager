using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class LeagueManagerContext : DbContext
{
    private string _DbPath;
    public LeagueManagerContext()
    {
        _DbPath = System.IO.Path.Join(AppDomain.CurrentDomain.BaseDirectory, "league-manager.db");
    }
    public DbSet<GameDay> GameDays { get; set; }
    public DbSet<League>? Leagues { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<Team>? Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_DbPath}");
        base.OnConfiguring(optionsBuilder);
    }
}