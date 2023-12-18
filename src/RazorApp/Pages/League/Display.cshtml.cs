using Entities.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class Display : PageModel
{
    private readonly ISender _Sender;
    
    public Display(ISender sender)
    {
        _Sender = sender;
    }
    
    public string Title { get; set; }
    public int TeamCount { get; set; }

    public async Task OnGet(int leagueId, CancellationToken cancellationToken)
    {
        var league = await _Sender.Send(new LeagueGetByIdQuery(leagueId), cancellationToken);
        Title = league.Title;
        TeamCount = league.Teams.Count;
    }
}