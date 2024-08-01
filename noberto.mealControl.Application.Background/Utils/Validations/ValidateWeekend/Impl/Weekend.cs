using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateWeekend.Impl;

public class Weekend : IValidateWeekendStrategy
{
    public CreateScheduleEventDTO Validate(DateOnly date)
    {
        CreateScheduleEventDTO scheduleEventDTO = new();

        if (date.DayOfWeek is DayOfWeek.Saturday
            || date.DayOfWeek is DayOfWeek.Sunday)
            scheduleEventDTO = new CreateScheduleEventDTO(null, date, null, null, true);

        return scheduleEventDTO;
    }
}
