using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class CreateManagerCommandHandle
    : IRequestHandler<CreateManagerCommnad, Manager>
{
    private readonly IManagerRepository _repository;

    public CreateManagerCommandHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Manager> Handle(CreateManagerCommnad request,
        CancellationToken cancellationToken)
    {
        var manager = new Manager(request.Registration, request.Name, request.Email, request.Password
            , request.Address.ZipCode, request.Address.Street, request.Address.Number,
            request.Address.Area, request.Address.City, request.Address.State, request.Address.Complement);

        return await _repository.CreateManagerAsync(manager);
    }
}
