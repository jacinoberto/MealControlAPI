using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using System.Collections;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Commands;

public class CreateTeamCommand : IRequest<IList<Team>>
{
    public Guid AdministratorId { get; set; }
    public IEnumerable<CreateWorkerCommand> Workers { get; set; }
    public Guid TeamManagementId { get; set; }

    public CreateTeamCommand()
    {
        
    }

    public CreateTeamCommand(Guid administratorId, IEnumerable<CreateWorkerCommand> workers,
        Guid teamManagementId)
    {
        AdministratorId = administratorId;
        Workers = workers;
        TeamManagementId = teamManagementId;
    }
}
