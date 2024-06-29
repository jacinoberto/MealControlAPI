using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Handles;

public class CreateTeamManagementCommandHandler
    : IRequestHandler<CreateTeamManagementCommand, TeamManagement>
{
    private readonly ITeamManagementRepository _repository;

    public CreateTeamManagementCommandHandler(ITeamManagementRepository repository)
    {
        _repository = repository;
    }

    public async Task<TeamManagement> Handle(CreateTeamManagementCommand request,
        CancellationToken cancellationToken)
    {
        var teamManagement = new TeamManagement(request.Sector);
        teamManagement.AdministratorId = request.AdministratorId;
        teamManagement.ManagerId = request.ManagerId;
        teamManagement.WorkId = request.WorkId;

        return await _repository.CreateTeamManagementAsync(teamManagement);
    }
}
