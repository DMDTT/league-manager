using Entities.Entities;

namespace RazorApp.Model;

public class Team(TeamContainer source)
{
    public int Goals { get; set; } = source.Goals;
    public int GoalsAgainst { get; set; } = source.GoalsAgainst;
    public int Points { get; set; } = source.Points;
    public int Wins { get; set; } = source.Wins;
    public int Losses { get; set; } = source.Losses;
    public int Draws { get; set; } = source.Draws;
    public string TeamCode { get; set; } = source.Team.Code;
    public int TeamId { get; set; } = source.Team.Id;
}