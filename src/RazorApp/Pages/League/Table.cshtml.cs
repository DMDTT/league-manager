using Entities.Services;
using MediatR;

namespace RazorApp.Pages.League;

public class Table : LeagueBase
{
    public Table(ISender sender) : base(sender)
    {
    }

    
    public async Task OnGet(int leagueId, int? gameday, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, gameday, cancellationToken);
    }
}