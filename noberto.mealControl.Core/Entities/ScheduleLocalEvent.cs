namespace noberto.mealControl.Core.Entities;

public class ScheduleLocalEvent : Identifier
{
    public Guid AdministratorId { get; set; }
    public Guid ScheduleEventId { get; set; }
    public Guid WorkId { get; set; }
    public Administrator Administrator { get; set; }
    public ScheduleEvent ScheduleEvent { get; set; }
    public Work Work { get; set; }
    public IEnumerable<Meal> Meals { get; set; }
}
