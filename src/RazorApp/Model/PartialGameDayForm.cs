namespace RazorApp.Model;

public class PartialGameDayForm
{
    public int TeamId { get; set; }
    public int LeagueId { get; set; }
    public int? SelectedGameDay { get; set; }
    public int MatchId { get; set; }
    public int Goals { get; set; }
}
