using MediatR;

namespace RazorApp.Pages.League;

public class Overview : LeagueBase
{
    public Overview(ISender sender) : base(sender)
    {
    }
    
    public string Title { get; set; }
    public int TeamCount { get; set; }

    public async Task OnGet(int leagueId, int? gameday, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, gameday, cancellationToken);
        Title = league.Title;
        TeamCount = league.Teams.Count;
    }
}