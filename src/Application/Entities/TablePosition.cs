namespace Entities.Entities;
public class TablePosition
{
    public int Position { get; set; }
    public int Goals { get; set; }
    public int GoalsAgainst { get; set; }
    public int Points { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
    public Team Team { get; set; }
}
