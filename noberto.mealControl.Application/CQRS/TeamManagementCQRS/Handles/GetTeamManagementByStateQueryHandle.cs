using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamManagementCQRS.Handles;

public class GetTeamManagementByStateQueryHandle
    : IRequestHandler<GetTeamManagementByStateQuery, IEnumerable<TeamManagement>>
{
    private readonly ITeamManagementRepository _repository;

    public GetTeamManagementByStateQueryHandle(ITeamManagementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TeamManagement>> Handle(GetTeamManagementByStateQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetTeamManagementByStateAsync(request.State);
    }
}
