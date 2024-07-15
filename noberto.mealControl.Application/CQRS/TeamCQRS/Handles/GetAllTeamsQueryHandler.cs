using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class GetAllTeamsQueryHandler
    : IRequestHandler<GetAllTeamsQuery, IEnumerable<Team>>
{
    private readonly ITeamRepository _repository;

    public GetAllTeamsQueryHandler(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Team>> Handle(GetAllTeamsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllTeams();
    }
}
