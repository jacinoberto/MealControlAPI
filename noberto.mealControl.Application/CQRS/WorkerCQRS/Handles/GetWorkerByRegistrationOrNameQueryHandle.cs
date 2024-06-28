using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Handles;

public class GetWorkerByRegistrationOrNameQueryHandle
    : IRequestHandler<GetWorkerByRegistrationOrNameQuery, IEnumerable<Worker>>
{
    private readonly IWorkerRepository _repository;

    public GetWorkerByRegistrationOrNameQueryHandle(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Worker>> Handle(GetWorkerByRegistrationOrNameQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetWorkersByRegistrationOrNameAsync(request.RegistrationOrName);
    }
}
