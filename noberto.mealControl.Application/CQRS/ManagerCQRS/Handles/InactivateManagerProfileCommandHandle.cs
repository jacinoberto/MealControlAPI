using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class InactivateManagerProfileCommandHandle
    : IRequestHandler<InactivateManagerProfileCommand, Manager>
{
    private readonly IManagerRepository _repository;

    public InactivateManagerProfileCommandHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Manager> Handle(InactivateManagerProfileCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.InactivateManagerProfileAsync(request.Id);
    }
}
