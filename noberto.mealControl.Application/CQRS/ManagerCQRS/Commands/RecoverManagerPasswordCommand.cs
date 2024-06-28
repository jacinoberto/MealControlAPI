using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;

public class RecoverManagerPasswordCommand : IRequest<Manager>
{
    public Guid Id { get; set; }
    public string Password { get; set; }

    public RecoverManagerPasswordCommand(Guid id, string password)
    {
        Id = id;
        Password = password;
    }
}
