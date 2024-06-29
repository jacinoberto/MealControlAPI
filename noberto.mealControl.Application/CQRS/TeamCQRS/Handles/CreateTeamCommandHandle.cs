using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class CreateTeamCommandHandle
    : IRequestHandler<CreateTeamCommand, Team>
{
    private readonly ITeamRepository _repository;

    public CreateTeamCommandHandle(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team();
        team.AdministratorId = request.AdministratorId;
        team.WorkerId = request.WorkerId;
        team.TeamManagementId = request.TeamManagementId;
        
        return await _repository.CreateTeamAsync(team);
    }
}
