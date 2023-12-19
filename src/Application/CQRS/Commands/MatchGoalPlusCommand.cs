using MediatR;

namespace Entities.CQRS.Commands;
public record MatchGoalPlusCommand(int LeagueId, int GameDay, int MatchId, int TeamId) : IRequest
{
}
