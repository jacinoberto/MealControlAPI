using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Handles;

public class DisableTeamManagementCommandHandle
    : IRequestHandler<DisableTeamManagementCommand, TeamManagement>
{
    private readonly ITeamManagementRepository _repository;
    private readonly ITeamRepository _teamRepository;

    public DisableTeamManagementCommandHandle(ITeamManagementRepository repository, ITeamRepository teamRepository)
    {
        _repository = repository;
        _teamRepository = teamRepository;
    }

    public async Task<TeamManagement> Handle(DisableTeamManagementCommand request,
        CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetTeamsByTeamManagementIdAsync(request.Id);

        foreach (var team in teams)
        {
            await _teamRepository.DisableTeamAsync(team.Id);
        }

        return await _repository.DisableTeamManagementAsync(request.Id);
    }
}
