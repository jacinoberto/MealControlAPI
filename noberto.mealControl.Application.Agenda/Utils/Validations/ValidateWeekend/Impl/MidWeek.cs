using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateWeekend.Impl;

public class MidWeek : IValidateWeekendStrategy
{
    public CreateScheduleEventDTO Validate(DateOnly date)
    {
        CreateScheduleEventDTO scheduleEventDTO = new();    

        if (date.DayOfWeek is not DayOfWeek.Saturday
            || date.DayOfWeek is not DayOfWeek.Sunday)   
            scheduleEventDTO = new CreateScheduleEventDTO(null, date, null, null, false);
        
        return scheduleEventDTO;
    }
}
