using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Queries;

public class GetTeamManagementByManagerIdQuery : IRequest<IEnumerable<TeamManagement>>
{
    public Guid ManagerId { get; set; }

    public GetTeamManagementByManagerIdQuery(Guid managerId)
    {
        ManagerId = managerId;
    }
}
