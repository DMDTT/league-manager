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
        var league = leagueManagerContext.Leagues
            .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Home)
            .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Away)
            .Include(mainEntity => mainEntity.GameDays)
            .Where(x => x.Id == request.Id)
            .OrderBy(mainEntity => mainEntity.Id) // Order main entities if needed
            .Select(mainEntity => new League
            {
                // Copy properties from mainEntity to the new League instance
                Id = mainEntity.Id,
                // ... copy other properties as needed

                // Order the GameDays collection within each League
                GameDays = mainEntity.GameDays.OrderBy(subEntity => subEntity.Id).ToList()
            })
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        return league;

        //var leagueQuery = leagueManagerContext.Leagues
        //    .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Home)
        //    .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Away)
        //    .Where(x => x.Id == request.Id)
        //    .Include(mainEntity => mainEntity.GameDays);

        //var leagueWithOrderedGameDays = leagueQuery
        //    .AsEnumerable() // Switch to LINQ to Objects
        //    .Select(mainEntity => new
        //    {
        //        MainEntity = mainEntity,
        //        OrderedGameDays = mainEntity.GameDays.OrderBy(subEntity => subEntity.Id)
        //    })
        //    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        //return leagueManagerContext.Leagues!
        //    .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Home)
        //    .Include(x => x.GameDays).ThenInclude(x => x.Matches).ThenInclude(x => x.Away)
        //    .Where(x => x.Id == request.Id)
        //    .OrderBy(x => x.GameDays.OrderBy(x => x.Matches.OrderBy(x => x.Id)))
        //    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
}