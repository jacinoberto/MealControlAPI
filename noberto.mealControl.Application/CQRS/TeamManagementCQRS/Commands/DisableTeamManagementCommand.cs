using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;

public class DisableTeamManagementCommand : IRequest<TeamManagement>
{
    public Guid Id { get; set; }

    public DisableTeamManagementCommand(Guid id)
    {
        Id = id;
    }
}
