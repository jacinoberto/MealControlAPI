using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;

public class CreateTeamManagementCommand : IRequest<TeamManagement>
{
    public Guid AdministratorId { get; set; }
    public Guid ManagerId { get; set; }
    public Guid WorkId { get; set; }
    public string Sector { get; set; }

    public CreateTeamManagementCommand(Guid administratorId, Guid managerId, Guid workId,
        string sector)
    {
        AdministratorId = administratorId;
        ManagerId = managerId;
        WorkId = workId;
        Sector = sector;
    }
}
