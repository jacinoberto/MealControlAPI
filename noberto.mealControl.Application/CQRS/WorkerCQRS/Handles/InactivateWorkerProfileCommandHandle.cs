using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Handles;

public class InactivateWorkerProfileCommandHandle
    : IRequestHandler<InactivateWorkerProfileCommand, Worker>
{
    private readonly IWorkerRepository _repository;
    private readonly ITeamRepository _teamRepository;

    public InactivateWorkerProfileCommandHandle(IWorkerRepository repository, ITeamRepository teamRepository)
    {
        _repository = repository;
        _teamRepository = teamRepository;
    }

    public async Task<Worker> Handle(InactivateWorkerProfileCommand request,
        CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetTeamsByWorkerIdAsync(request.Id);

        foreach (var team in teams)
        {
            await _teamRepository.DisableTeamAsync(team.Id);
        }

        return await _repository.InactivateWorkerProfileAsync(request.Id);
    }
}
