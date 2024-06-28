using MediatR;
using noberto.mealControl.Application.CQRS.AddressCQRS.Command;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;

public class CreateManagerCommnad : IRequest<Manager>
{
    public string Registration { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public CreateAddressCommand Address { get; set; }

    public CreateManagerCommnad(string registration, string name, string email, string password,
        CreateAddressCommand address)
    {
        Registration = registration;
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }
}
