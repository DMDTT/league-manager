using Entities.CQRS.Queries;
using Entities.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class LeagueBase : PageModel
{
    private readonly ISender _Sender;

    public LeagueBase(ISender sender)
    {
        _Sender = sender;
    }

    protected ISender Sender => _Sender;

    public int LeagueId { get; set; }
    
    public int? SelectedGameDay { get; set; }
    
    public Entities.Entities.Table TableResult { get; set; }

    public List<int> GameDays { get; set; } = new List<int>();

    protected async Task<Application.Entities.League> GetLeague(int leagueId, int? gameday, CancellationToken cancellationToken)
    {
        var league = await Sender.Send(new LeagueGetByIdQuery(leagueId), cancellationToken);
        
        for (int i = 0; i < league.GameDays.Count; i++)
        {
            GameDays.Add(i + 1);
        }
        
        LeagueId = leagueId;
        TableResult = new TableCalculator().Get(league, gameday ?? league.GameDays.Count);
        SelectedGameDay = gameday ?? league.GameDays.Count;
        
        ViewData[Consts.LeagueId] = LeagueId;
        ViewData[Consts.GameDays] = GameDays;
        ViewData[Consts.SelectedGameDay] = SelectedGameDay;
        return league;
    }
}