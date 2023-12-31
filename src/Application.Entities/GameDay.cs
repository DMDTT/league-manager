namespace Application.Entities;

public class GameDay
{
    public int Id { get; set; }
    public League League { get; set; }
    public int Day { get; set; }

    public List<Match> Matches { get; set; } = new List<Match>();
}