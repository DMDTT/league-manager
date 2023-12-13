using MediatR;

namespace Entities.CQRS.Commands;

public record LeagueAddCommand(string Title, int TeamCount) : IRequest<int>
{
}