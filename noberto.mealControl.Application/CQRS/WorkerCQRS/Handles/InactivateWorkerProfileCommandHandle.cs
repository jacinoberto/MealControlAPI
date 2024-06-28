using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkerCQRS.Handles;

public class InactivateWorkerProfileCommandHandle
    : IRequestHandler<InactivateWorkerProfileCommand, Worker>
{
    private readonly IWorkerRepository _repository;

    public InactivateWorkerProfileCommandHandle(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Worker> Handle(InactivateWorkerProfileCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.InactivateWorkerProfileAsync(request.Id);
    }
}
