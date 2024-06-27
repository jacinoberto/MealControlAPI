using noberto.mealControl.Core.Entity;

namespace noberto.mealControl.Core.Entities;

public class Administrator : Identifier
{
    public User User { get; private set; }

    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public IEnumerable<Work> Works { get; set; }
    public IEnumerable<TeamManagement> TeamManagement { get; set; }
    public IEnumerable<Team> Teams { get; set; }
    public IEnumerable<ScheduleEvent> ScheduleEvents { get; set; }
    public IEnumerable<ScheduleLocalEvent> ScheduleLocalEvents { get; set; }
    public IEnumerable<Meal> Meals { get; set; }

    public Administrator() {}

    public Administrator(User user, Address address)
    {
        User = AddUser(user.Registration, user.Name, user.Email, user.Password);
        Address = AddAddress(address.ZipCode, address.Street, address.Number, address.Area,
            address.City, address.State, address.Complement);
    }

    public User AddUser(string registration, string name, string email, string password)
    {
        return new(registration, name, email, password);
    }

    public Address AddAddress(string zipCode, string street, int number, string area,
        string city, string state, string? complement)
    {
        return new(zipCode, street, number, area, city, state, complement);
    }
}
