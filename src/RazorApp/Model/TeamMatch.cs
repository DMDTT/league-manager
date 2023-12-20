namespace RazorApp.Model;

public class TeamMatch
{
    public TeamMatch(Application.Entities.Match match)
    {
        Id = match.Id;
        IdHome = match.Home.Id;
        CodeHome = match.Home.Code;
        GoalsHome = match.GoalsHome;

        IdAway = match.Away.Id;
        CodeAway = match.Away.Code;
        GoalsAway = match.GoalsAway;

        GameDay = match.GameDay.Day;
    }

    public int Id { get; set; }
    public int IdHome { get; set; }
    public int? GoalsHome { get; set; }
    public string CodeHome { get; set; }
    public int IdAway { get; set; }
    public string CodeAway { get; set; }
    public int? GoalsAway { get; set; }
    
    public int GameDay { get; set; }
}