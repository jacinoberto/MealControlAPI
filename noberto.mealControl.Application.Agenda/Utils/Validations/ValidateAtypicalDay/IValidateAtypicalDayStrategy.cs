using noberto.mealControl.Application.DTOs.MealDTO;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateAtypicalDay;

public interface IValidateAtypicalDayStrategy
{
    Task<CreateMealDTO> Validate(Guid teamId, Guid scheduleEventId, Guid scheduleLocalEventId);
}
