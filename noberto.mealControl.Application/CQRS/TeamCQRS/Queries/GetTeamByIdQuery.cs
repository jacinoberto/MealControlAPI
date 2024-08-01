using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Queries;

public class GetTeamByIdQuery : IRequest<Team>
{
    public Guid Id { get; set; }

    public GetTeamByIdQuery(Guid id)
    {
        Id = id;
    }
}
