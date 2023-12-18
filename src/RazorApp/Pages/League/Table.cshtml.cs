using Application.Entities;
using Entities.CQRS.Queries;
using Entities.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class Table : PageModel
{
    private readonly ISender _Sender;

    public Table(ISender sender)
    {
        _Sender = sender;
    }

    public Entities.Entities.Table TableResult { get; set; }
    public async Task OnGet(int leagueId, CancellationToken cancellationToken)
    {
        var league = await _Sender.Send(new LeagueGetByIdQuery(leagueId), cancellationToken);
        TableResult = new TableCalculator().Get(league, league.GameDays.Count);
    }
}