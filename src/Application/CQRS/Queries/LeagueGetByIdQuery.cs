using Application.Entities;
using MediatR;

namespace Entities.CQRS.Queries;

public record LeagueGetByIdQuery(int Id) : IRequest<League>
{
    
}