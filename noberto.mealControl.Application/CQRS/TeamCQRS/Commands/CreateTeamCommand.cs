using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Commands;

public class CreateTeamCommand : IRequest<Team>
{
    public Guid AdministratorId { get; set; }
    public Guid WorkerId { get; set; }
    public Guid TeamManagementId { get; set; }

    public CreateTeamCommand(Guid administratorId, Guid workerId, Guid teamManagementId)
    {
        AdministratorId = administratorId;
        WorkerId = workerId;
        TeamManagementId = teamManagementId;
    }
}
