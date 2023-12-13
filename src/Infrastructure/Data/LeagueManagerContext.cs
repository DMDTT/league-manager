using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class LeagueManagerContext : DbContext
{
    public LeagueManagerContext(DbContextOptions<LeagueManagerContext> options) : base(options)
    {
    }
    
    public LeagueManagerContext() : base(new  DbContextOptions<LeagueManagerContext>()) { }

    public DbSet<GameDay> GameDays { get; set; }
    public DbSet<League>? Leagues { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<Team>? Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={"leaguemanager.db"}");
        }
        
        base.OnConfiguring(optionsBuilder);
    }
}