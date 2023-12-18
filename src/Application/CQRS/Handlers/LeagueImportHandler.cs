using Entities.CQRS.Commands;
using Entities.Services;
using Infrastructure.Data;
using MediatR;

namespace Entities.CQRS.Handlers;

public class LeagueImportHandler(LeagueManagerContext leagueManagerContext) : IRequestHandler<LeagueImportCommand, int>
{
    private readonly LeagueManagerContext _LeagueManagerContext = leagueManagerContext;
    public async Task<int> Handle(LeagueImportCommand request, CancellationToken cancellationToken)
    {
        var league = L98ToLeague.Migrate(request.Path);
        await _LeagueManagerContext.Leagues.AddAsync(league);
        await _LeagueManagerContext.SaveChangesAsync();
        return league.Id;
    }
}