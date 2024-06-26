using noberto.mealControl.Core.Entity;

namespace noberto.mealControl.Core.Entities;

public class Manager : Identifier
{
    public User User { get; private set; }

    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public IEnumerable<TeamManagement> TeamManagements { get; set; }

    public Manager(string registration, string name, string email, string password,
        string zipCode, string street, int number, string area, string city, string state,
        string? complement)
    {
        User = new(registration, name, email, password);
        Address = new(zipCode, street, number, area, area, city, complement);
    }
}
