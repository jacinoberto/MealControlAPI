using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class GetTeamsByManagerIdQueryHandle
    : IRequestHandler<GetTeamByManagerIdQuery, IEnumerable<Team>>
{
    private readonly ITeamRepository _repository;

    public GetTeamsByManagerIdQueryHandle(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Team>> Handle(GetTeamByManagerIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetTeamsByIdManagerAsync(request.ManagerId);
    }
}
