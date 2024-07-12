using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateWeekend;

public interface IValidateWeekendStrategy
{
    public CreateScheduleEventDTO Validate(DateOnly date);
}
