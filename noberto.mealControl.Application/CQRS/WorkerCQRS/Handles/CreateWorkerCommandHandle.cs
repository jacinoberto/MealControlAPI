using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Handles;

public class CreateWorkerCommandHandle
    : IRequestHandler<CreateWorkerCommand, Worker>
{
    private readonly IWorkerRepository _repository;

    public CreateWorkerCommandHandle(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Worker> Handle(CreateWorkerCommand request,
        CancellationToken cancellationToken)
    {
        var worker = new Worker(request.Registration, request.Name);

        return await _repository.CreateWorkerAsync(worker);
    }
}
