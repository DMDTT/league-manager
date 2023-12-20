using Entities.Services;
using MediatR;

namespace RazorApp.Pages.League;

public class FeverChart : LeagueBase
{
    public FeverChart(ISender sender) : base(sender)
    {
    }
    public int TeamId { get; set; }
    
    public string TeamCode { get; set; }
    
    public string FeverData { get; set; }
    public async Task OnGet(int leagueId, int? teamId, CancellationToken cancellationToken)
    {
        var league = await GetLeague(leagueId, null, cancellationToken);
        List<int> position = new List<int>();
        for (int i = 1; i <= GameDays.Count; i++)
        {
            var teams = new TableCalculator().Get(league, i).Teams;
            var team = teams.Single(x => x.Team.Id == teamId);
            position.Add(teams.IndexOf(team) + 1);
        }

        FeverData = $"{{\"labels\": {Newtonsoft.Json.JsonConvert.SerializeObject(GameDays)}, \"data\": {Newtonsoft.Json.JsonConvert.SerializeObject(position)}}}";

    }
}