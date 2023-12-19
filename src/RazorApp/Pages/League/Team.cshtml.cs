using MediatR;
using RazorApp.Model;

namespace RazorApp.Pages.League;

public class Team : LeagueBase
{
    public Team(ISender sender) : base(sender)
    {
    }
    public int TeamId { get; set; }
    
    public string TeamCode { get; set; }
    public List<TeamMatch> Matches { get; set; } = new List<TeamMatch>();
    public async Task OnGet(int leagueId, int? teamId, CancellationToken cancellationToken)
    {
        TeamId = teamId!.Value;
        var league = await GetLeague(leagueId, null, cancellationToken);

        foreach (var gameDay in league.GameDays)
        {
            foreach (var match in gameDay.Matches)
            {
                if (match.Home.Id == teamId || match.Away.Id == teamId)
                {
                    Matches.Add(new TeamMatch(match));
                }
            }
        }
        
    }
}