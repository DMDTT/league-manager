using Application.Entities;
using MediatR;

namespace RazorApp.Pages.League;

public class GameDay : LeagueBase
{
    public List<Match> Matches { get; set; } = new List<Match>();

    public GameDay(ISender sender) : base(sender)
    {
    }
    
    public async Task OnGet(int leagueId, int? gameDay, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, gameDay, cancellationToken);
        var gameday = league.GameDays.FirstOrDefault(x => x.Day == gameDay);
        gameday ??= gameday ?? league.GameDays.LastOrDefault();
        foreach (var match in gameday?.Matches ?? new List<Match>())
        {
            Matches.Add(match);
        }
    }
}