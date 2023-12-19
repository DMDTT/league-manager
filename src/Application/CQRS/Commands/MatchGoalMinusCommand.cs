using MediatR;

namespace Entities.CQRS.Commands;
public record MatchGoalMinusCommand(int LeagueId, int GameDay, int MatchId, int TeamId) : IRequest
{
}
