using MediatR;

namespace Entities.CQRS.Commands;

public record LeagueImportCommand(string Path)  : IRequest<int>
{
}