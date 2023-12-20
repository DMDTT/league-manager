using MediatR;

namespace Entities.CQRS.Commands;
public record RemoveTeamFromLeagueCommand(int TeamId, int LeagueId) : IRequest
{
}
