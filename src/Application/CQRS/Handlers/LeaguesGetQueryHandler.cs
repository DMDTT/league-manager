using Application.Entities;
using Entities.CQRS.Queries;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.CQRS.Handlers;

public class LeaguesGetQueryHandler(LeagueManagerContext leagueManagerContext)
    : IRequestHandler<LeaguesGetQuery, List<League>>
{
    private readonly LeagueManagerContext _LeagueManagerContext = leagueManagerContext;

    public Task<List<League>> Handle(LeaguesGetQuery request, CancellationToken cancellationToken)
    {
        return leagueManagerContext.Leagues!.ToListAsync(cancellationToken: cancellationToken);
    }
}