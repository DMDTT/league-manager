using Entities.CQRS.Commands;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.CQRS.Handlers;
public class RemoveTeamFromLeagueHandler(LeagueManagerContext leagueManagerContext) : IRequestHandler<RemoveTeamFromLeagueCommand>
{
    private readonly LeagueManagerContext _LeagueManagerContext = leagueManagerContext;
    public async Task Handle(RemoveTeamFromLeagueCommand request, CancellationToken cancellationToken)
    {
        var league = await _LeagueManagerContext.Leagues
            .Include(x => x.Teams)
            .Where(x => x.Id == request.LeagueId)
            .SingleAsync(cancellationToken: cancellationToken);

        var team = league.Teams.SingleOrDefault(x => x.Id == request.TeamId);
        if (team != null)
        {
            league.Teams.Remove(team);
            _LeagueManagerContext.Teams.Remove(team);
            await _LeagueManagerContext.SaveChangesAsync(cancellationToken);
        }
    }
}
