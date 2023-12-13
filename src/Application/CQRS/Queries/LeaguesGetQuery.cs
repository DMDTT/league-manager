using Application.Entities;
using MediatR;

namespace Entities.CQRS.Queries;

public class LeaguesGetQuery : IRequest<List<League>>
{
}