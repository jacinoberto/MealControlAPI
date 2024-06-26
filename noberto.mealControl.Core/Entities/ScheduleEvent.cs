using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class ScheduleEvent : Identifier
{
    public DateOnly MealDate { get; private set; }
    public string? Description { get; private set; }
    public bool Atypical { get; private set; }

    public Guid AdministratorId { get; set; }
    public Administrator Administrator { get; set; }
    public IEnumerable<ScheduleLocalEvent> ScheduleLocalEvents { get; set; }

    public ScheduleEvent(DateOnly mealDate, string? description)
    {
        ValidateScheduleEventData(mealDate, description);
    }

    /// <summary>
    /// Validar dados informados para instanciar um novo Agendamento de Evento
    /// </summary>
    /// <param name="mealDate"></param>
    /// <param name="description"></param>
    private void ValidateScheduleEventData(DateOnly mealDate, string? description)
    {
        InvalidEntityDataException.When(mealDate == null,
            BadInternalOrdersEnum.MealDateIsNull.ToString());

        InvalidEntityDataException.When(mealDate < DateOnly.FromDateTime(DateTime.UtcNow),
            BadInternalOrdersEnum.PastMealDate.ToString());

        InvalidEntityDataException.When(description?.Length < 5,
            BadInternalOrdersEnum.ShortDescription.ToString());

        InvalidEntityDataException.When(description?.Length > 100,
            BadInternalOrdersEnum.LongDescription.ToString());

        MealDate = mealDate;
        Description = description;
        Atypical = true;
    }
}
