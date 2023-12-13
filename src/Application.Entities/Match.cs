namespace Application.Entities;

public class Match
{
    public int Id { get; set; }
    public Team Home { get; set; }
    public Team Away { get; set; }
    public int GoalsHome { get; set; }
    public int GoalsAway { get; set; }
    public GameDay GameDay { get; set; }
}