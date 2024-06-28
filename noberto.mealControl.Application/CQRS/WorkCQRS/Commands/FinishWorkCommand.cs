using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Commands;

public class FinishWorkCommand : IRequest<Work>
{
    public Guid Id { get; set; }

    public FinishWorkCommand(Guid id)
    {
        Id = id;
    }
}
