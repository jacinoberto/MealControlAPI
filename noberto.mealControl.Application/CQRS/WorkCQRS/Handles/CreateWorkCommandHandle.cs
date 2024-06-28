using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class CreateWorkCommandHandle
    : IRequestHandler<CreateWorkCommand, Work>
{
    private readonly IWorkRepository _repository;

    public CreateWorkCommandHandle(IWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<Work> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
    {
        var work = new Work(request.Identification, request.StartDate, request.Address.Street,
            request.Address.ZipCode, request.Address.Number, request.Address.Area,
            request.Address.City, request.Address.State, request.Address.Complement);

        return await _repository.CreateWorkAsync(work);
    }
}
