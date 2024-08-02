using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Handles;

public class GetTeamManagementByManagerIdQuerryHandle
    : IRequestHandler<GetTeamManagementByManagerIdQuery, IEnumerable<TeamManagement>>
{
    private readonly ITeamManagementRepository _repository;

    public GetTeamManagementByManagerIdQuerryHandle(ITeamManagementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TeamManagement>> Handle(GetTeamManagementByManagerIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetTeamManagementByManagerIdAsync(request.ManagerId);
    }
}
