using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;

public class CreateWorkerCommand : IRequest<Worker>
{
    public string Registration { get; set; }
    public string Name { get; set; }

    public CreateWorkerCommand(string registration, string name)
    {
        Registration = registration;
        Name = name;
    }
}
