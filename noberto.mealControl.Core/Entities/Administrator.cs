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

    public Administrator(string registration, string name, string email, string password,
        string zipCode, string street, int number, string area, string city, string state,
        string? complement)
    {
        User = new(registration, name, email, password);
        Address = new(zipCode, street, number, area, city, state, complement);
    }
}
