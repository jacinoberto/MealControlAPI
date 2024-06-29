using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Queries;

public class GetTeamByManagerIdQuery : IRequest<IEnumerable<Team>>
{
    public Guid ManagerId { get; set; }

    public GetTeamByManagerIdQuery(Guid managerId)
    {
        ManagerId = managerId;
    }
}
