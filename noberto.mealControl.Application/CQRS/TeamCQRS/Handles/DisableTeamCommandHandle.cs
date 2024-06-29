using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class DisableTeamCommandHandle
    : IRequestHandler<DisableTeamCommand, Team>
{
    private readonly ITeamRepository _repository;

    public DisableTeamCommandHandle(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<Team> Handle(DisableTeamCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DisableTeamAsync(request.Id);
    }
}
