using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Queries;

public class GetWorkerByRegistrationOrNameQuery : IRequest<IEnumerable<Worker>>
{
    public string RegistrationOrName { get; set; }

    public GetWorkerByRegistrationOrNameQuery(string registrationOrName)
    {
        RegistrationOrName = registrationOrName;
    }
}
