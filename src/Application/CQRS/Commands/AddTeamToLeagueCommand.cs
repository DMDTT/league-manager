using MediatR;

namespace Entities.CQRS.Commands;

public record AddTeamToLeagueCommand(string TeamCode, int LeagueId) : IRequest<int>
{
    
}