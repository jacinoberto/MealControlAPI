using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class GetTeamByIdQueryHandle
    : IRequestHandler<GetTeamByIdQuery, Team>
{
    private readonly ITeamRepository _repository;

    public GetTeamByIdQueryHandle(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetTeamByIdAsync(request.Id);
    }
}
