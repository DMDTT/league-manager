namespace Entities.Entities;

public class League
{
    public int Id { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();

    public List<GameDay> GameDays { get; set; } = new List<GameDay>();
}