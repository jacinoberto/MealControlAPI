using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;

public class InactivateWorkerProfileCommand : IRequest<Worker>
{
    public Guid Id { get; set; }

    public InactivateWorkerProfileCommand(Guid id)
    {
        Id = id;
    }
}
