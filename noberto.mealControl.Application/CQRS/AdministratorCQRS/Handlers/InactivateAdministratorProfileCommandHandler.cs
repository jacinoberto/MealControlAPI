using MediatR;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Handlers;

public class InactivateAdministratorProfileCommandHandler
    : IRequestHandler<InactivateAdministratorProfileCommand, Administrator>
{
    private readonly IAdministratorRepository _repository;

    public InactivateAdministratorProfileCommandHandler(IAdministratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Administrator> Handle(InactivateAdministratorProfileCommand request, CancellationToken cancellationToken)
    {
        return await _repository.InactivateAdministratorProfileAsync(request.Id);
    }
}
