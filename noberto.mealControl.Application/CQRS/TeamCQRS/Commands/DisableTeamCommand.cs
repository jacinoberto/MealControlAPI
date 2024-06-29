using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Commands;

public class DisableTeamCommand : IRequest<Team>
{
    public Guid Id { get; set; }

    public DisableTeamCommand(Guid id)
    {
        Id = id;
    }
}
