using MediatR;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Handlers;

public class CreateAdministratorCommandHandler
    : IRequestHandler<CreateAdministratorCommand, Administrator>
{
    private readonly IAdministratorRepository _repository;

    public CreateAdministratorCommandHandler(IAdministratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Administrator> Handle(CreateAdministratorCommand request,
        CancellationToken cancellationToken)
    {
        var administrator = new Administrator(request.Registration, request.Name, request.Email, request.Password,
            request.Address.ZipCode, request.Address.Street, request.Address.Number,
            request.Address.Area, request.Address.City, request.Address.State, request?.Address.Complement);

        return await _repository.CreateAdministratorAsync(administrator);
    }
}
