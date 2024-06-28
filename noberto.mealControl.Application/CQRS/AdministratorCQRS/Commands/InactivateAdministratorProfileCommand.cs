using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;

public class InactivateAdministratorProfileCommand : IRequest<Administrator>
{
    public Guid Id { get; set; }

    public InactivateAdministratorProfileCommand(Guid id)
    {
        Id = id;
    }
}
