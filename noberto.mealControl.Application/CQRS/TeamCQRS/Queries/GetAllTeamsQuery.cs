using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Queries;

public class GetAllTeamsQuery : IRequest<IEnumerable<Team>>
{
}
