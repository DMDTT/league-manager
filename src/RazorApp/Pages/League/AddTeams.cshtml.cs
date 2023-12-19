using Entities.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RazorApp.Pages.League;

public class AddTeams : LeagueBase
{
    public AddTeams(ISender sender) : base(sender)
    {
    }
    
    public string Title { get; set; }
    public int TeamCount { get; set; }
    
    [BindProperty] public string NewTeam { get; set; }

    public List<RazorApp.Model.Team> Teams { get; set; } = new List<Model.Team>();
    
    public async Task OnGet(int leagueId, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, null, cancellationToken);
        Title = league.Title;
        TeamCount = league.Teams.Count;
        foreach (Application.Entities.Team team in league.Teams)
        {
            Teams.Add(new RazorApp.Model.Team(team));
        }
    }
    
    public async Task OnPost([FromForm]int leagueId, CancellationToken cancellationToken)
    {
        int result = await Sender.Send(new AddTeamToLeagueCommand(NewTeam, leagueId));
        var league = await GetLeague(leagueId, null, cancellationToken);
        foreach (Application.Entities.Team team in league.Teams)
        {
            Teams.Add(new RazorApp.Model.Team(team));
        }
        
        Title = league.Title;
        TeamCount = league.Teams.Count;
    }
}