using Entities.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RazorApp.Model;

namespace RazorApp.Pages.League;

public class GameDay : LeagueBase
{
    public List<Match> Matches { get; set; } = new List<Match>();

    [BindProperty]
    public GoalAction Action { get; set; }

    public GameDay(ISender sender) : base(sender)
    {
    }
    
    public async Task OnGet(int leagueId, int? gameDay, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, gameDay, cancellationToken);
        var gameday = league.GameDays.FirstOrDefault(x => x.Day == gameDay);
        gameday ??= gameday ?? league.GameDays.LastOrDefault();
        foreach (var match in gameday?.Matches ?? new List<Application.Entities.Match>())
        {
            Matches.Add(new Match(match));
        }
    }

    public async Task<IActionResult> OnPost([FromForm] int leagueId, [FromForm] int selectedGameDay, [FromForm] int matchId, [FromForm] int teamId, CancellationToken cancellationToken)
    {
        switch (Action)
        {
            case GoalAction.Plus:
                await Sender.Send(new MatchGoalPlusCommand(leagueId, selectedGameDay, matchId, teamId), cancellationToken);
                break;
            case GoalAction.Minus:
                await Sender.Send(new MatchGoalMinusCommand(leagueId, selectedGameDay, matchId, teamId), cancellationToken);
                break;

        }

        return RedirectToPage("/League/GameDay", new { leagueId = leagueId, gameDay = selectedGameDay }); // Redirect to a different page after successful upload
    }

    public enum GoalAction
    {
        Plus,
        Minus
    }
}