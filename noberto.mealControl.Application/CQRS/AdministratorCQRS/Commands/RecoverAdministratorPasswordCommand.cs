using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;

public class RecoverAdministratorPasswordCommand : IRequest<Administrator>
{
    public Guid Id { get; set; }
    public string Password { get; set; }

    public RecoverAdministratorPasswordCommand(Guid id, string password)
    {
        Id = id;
        Password = password;
    }
}
