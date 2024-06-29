using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Queries;

public class GetTeamManagementByStateQuery : IRequest<IEnumerable<TeamManagement>>
{
    public string State { get; set; }

    public GetTeamManagementByStateQuery(string state)
    {
        State = state;
    }
}
