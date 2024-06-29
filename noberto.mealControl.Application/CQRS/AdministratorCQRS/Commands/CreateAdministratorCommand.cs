using MediatR;
using noberto.mealControl.Application.CQRS.AddressCQRS.Command;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;

public class CreateManagerCommand : IRequest<Administrator>
{
    public string Registration { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public CreateAddressCommand Address { get; set; }

    public CreateManagerCommand(string registration, string name, string email,
        string password, CreateAddressCommand address)
    {
        Registration = registration;
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }
}
