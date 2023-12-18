using Application.Entities;
using Entities.CQRS.Queries;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.CQRS.Handlers;

public class LeagueGetByIdQueryHandler(LeagueManagerContext leagueManagerContext)
    : IRequestHandler<LeagueGetByIdQuery, League?>
{
    public Task<League?> Handle(LeagueGetByIdQuery request, CancellationToken cancellationToken)
    {
        return leagueManagerContext.Leagues!
            .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Home)
            .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Away)
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
}