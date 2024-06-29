using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class FinishWorkCommandHandle
    : IRequestHandler<FinishWorkCommand, Work>
{
    private readonly IWorkRepository _repository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamManagementRepository _teamManagementRepository;

    public FinishWorkCommandHandle(IWorkRepository repository, ITeamRepository teamRepository,
        ITeamManagementRepository teamManagementRepository)
    {
        _repository = repository;
        _teamRepository = teamRepository;
        _teamManagementRepository = teamManagementRepository;
    }

    public async Task<Work> Handle(FinishWorkCommand request, CancellationToken cancellationToken)
    {
        var teamManagements = await _teamManagementRepository.GetTeamManagementByWorkIdAsync(request.Id);
        var teams = await _teamRepository.GetTeamsByWorkerIdAsync(request.Id);

        foreach (var team in teams)
        {
            await _teamRepository.DisableTeamAsync(team.Id);
        }

        foreach (var teamManagement in teamManagements)
        {
            await _teamManagementRepository.DisableTeamManagementAsync(teamManagement.Id);
        }

        return await _repository.FinishWorkAsync(request.Id);
    }
}
