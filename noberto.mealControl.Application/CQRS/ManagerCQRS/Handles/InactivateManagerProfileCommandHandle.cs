using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class InactivateManagerProfileCommandHandle
    : IRequestHandler<InactivateManagerProfileCommand, Manager>
{
    private readonly IManagerRepository _repository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamManagementRepository _teamManagementRepository;

    public InactivateManagerProfileCommandHandle(IManagerRepository repository,
        ITeamManagementRepository teamManagementRepository, ITeamRepository teamRepository)
    {
        _repository = repository;
        _teamManagementRepository = teamManagementRepository;
        _teamRepository = teamRepository;
    }

    public async Task<Manager> Handle(InactivateManagerProfileCommand request,
        CancellationToken cancellationToken)
    {
        var teamManagements = await _teamManagementRepository.GetTeamManagementByManagerIdAsync(request.Id);
        var teams = await _teamRepository.GetTeamsByManagerIdAsync(request.Id);

        foreach (var team in teams)
        {
            await _teamRepository.DisableTeamAsync(team.Id);
        }

        foreach (var teamManagement in teamManagements)
        {
            await _teamManagementRepository.DisableTeamManagementAsync(teamManagement.Id);
        }

        return await _repository.InactivateManagerProfileAsync(request.Id);
    }
}
