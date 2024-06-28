using MediatR;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Handlers;

public class RecoverAdministratorPasswordCommandHandler
    : IRequestHandler<RecoverAdministratorPasswordCommand, Administrator>
{
    private readonly IAdministratorRepository _repository;

    public RecoverAdministratorPasswordCommandHandler(IAdministratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Administrator> Handle(RecoverAdministratorPasswordCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.RecoverAdministratorPasswordAsync(request.Id, request.Password);
    }
}
