using Entities.CQRS.Commands;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.CQRS.Handlers;
public class MatchGoalMinusHandler(LeagueManagerContext leagueManagerContext) : IRequestHandler<MatchGoalMinusCommand>
{
    private readonly LeagueManagerContext _LeagueManagerContext = leagueManagerContext;

    public async Task Handle(MatchGoalMinusCommand request, CancellationToken cancellationToken)
    {
        var match = await _LeagueManagerContext.Matches
            .Include(x => x.Home)
            .Include(x => x.Away)
            .Where(x => x.Id == request.MatchId)
            .Where(x => x.GameDay.Day == request.GameDay)
            .Where(x => x.GameDay.League.Id == request.LeagueId)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (match.Home.Id == request.TeamId)
        {
            match.GoalsHome--;
        }
        else if (match.Away.Id == request.TeamId)
        {
            match.GoalsAway--;
        }

        await _LeagueManagerContext.SaveChangesAsync(cancellationToken);
    }
}
