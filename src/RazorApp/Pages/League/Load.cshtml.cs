using Entities.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class Load : PageModel
{
    private readonly ISender _Sender;

    public Load(ISender sender)
    {
        _Sender = sender;
    }

    public List<Application.Entities.League> Leagues { get; set; }
    public async Task OnGet(CancellationToken cancellationToken)
    {
        Leagues = await _Sender.Send(new LeaguesGetQuery(), cancellationToken);
    }
}