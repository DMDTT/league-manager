using Entities.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League.Display;

public class Index : PageModel
{
    private readonly ISender _Sender;

    public Index(ISender sender)
    {
        _Sender = sender;
    }

    [BindProperty] public string Title { get; set; }
    [BindProperty] public int TeamCount { get; set; }
    
    public async Task OnGet(int leagueId, CancellationToken cancellationToken)
    {
        var league = await _Sender.Send(new LeagueGetByIdQuery(leagueId), cancellationToken);
        Title = league.Title;
    }
}