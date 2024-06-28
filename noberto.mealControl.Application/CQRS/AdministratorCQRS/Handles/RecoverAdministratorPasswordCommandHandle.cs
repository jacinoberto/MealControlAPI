using MediatR;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Handles;

public class RecoverAdministratorPasswordCommandHandle
    : IRequestHandler<RecoverAdministratorPasswordCommand, Administrator>
{
    private readonly IAdministratorRepository _repository;

    public RecoverAdministratorPasswordCommandHandle(IAdministratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Administrator> Handle(RecoverAdministratorPasswordCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.RecoverAdministratorPasswordAsync(request.Id, request.Password);
    }
}
