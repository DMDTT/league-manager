using Application.Entities;
using Entities.CQRS.Commands;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.CQRS.Handlers;

public class AddTeamToLeagueHandler(LeagueManagerContext leagueManagerContext)
    : IRequestHandler<AddTeamToLeagueCommand, int>
{
    private readonly LeagueManagerContext _LeagueManagerContext = leagueManagerContext;

    public async Task<int> Handle(AddTeamToLeagueCommand request, CancellationToken cancellationToken)
    {
        var league = await _LeagueManagerContext.Leagues
            .Include(x => x.Teams)
            .Where(x => x.Id == request.LeagueId)
            .SingleAsync();
        if (league.Teams.Any(x => x.Code.Equals(request.TeamCode)))
        {
            throw new Exception("Team already added");
        }

        var teams = new Team() { Code = request.TeamCode };
        league.Teams.Add(teams);
        _LeagueManagerContext.Teams.Add(teams);
        await _LeagueManagerContext.SaveChangesAsync();
        return teams.Id;
    }
}