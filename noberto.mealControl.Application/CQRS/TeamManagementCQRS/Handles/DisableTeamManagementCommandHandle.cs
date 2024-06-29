using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Handles;

public class DisableTeamManagementCommandHandle
    : IRequestHandler<DisableTeamManagementCommand, TeamManagement>
{
    private readonly ITeamManagementRepository _repository;

    public DisableTeamManagementCommandHandle(ITeamManagementRepository repository)
    {
        _repository = repository;
    }

    public async Task<TeamManagement> Handle(DisableTeamManagementCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.DisableTeamManagementAsync(request.Id);
    }
}
