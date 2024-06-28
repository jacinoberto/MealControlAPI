using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class RecoverManagerPasswordCommandHandle
    : IRequestHandler<RecoverManagerPasswordCommand, Manager>
{
    private readonly IManagerRepository _repository;

    public RecoverManagerPasswordCommandHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Manager> Handle(RecoverManagerPasswordCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.RecoverManagerPasswordAsync(request.Id, request.Password);
    }
}
