using Application.Entities;
using Entities.CQRS.Commands;
using Infrastructure.Data;
using MediatR;

namespace Entities.CQRS.Handlers;

public class LeagueAddHandler : IRequestHandler<LeagueAddCommand, int>
{
    private readonly LeagueManagerContext _LeagueManagerContext;

    public LeagueAddHandler(LeagueManagerContext leagueManagerContext)
    {
        _LeagueManagerContext = leagueManagerContext;
    }

    public async Task<int> Handle(LeagueAddCommand request, CancellationToken cancellationToken)
    {
        var result = await _LeagueManagerContext.Leagues!.AddAsync(new League() {Title = request.Title}, cancellationToken);
        await _LeagueManagerContext.SaveChangesAsync(cancellationToken);
        return result.Entity.Id;
    }
}