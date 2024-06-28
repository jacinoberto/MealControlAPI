using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.AddressCQRS.Command;

public class CreateAddressCommand : IRequest<Address>
{
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string Area { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? Complement { get; set; }

    public CreateAddressCommand(string zipCode, string street, int number, string area,
        string city, string state, string? complement)
    {
        ZipCode = zipCode;
        Street = street;
        Number = number;
        Area = area;
        City = city;
        State = state;
        Complement = complement;
    }
}
