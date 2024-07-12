namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateWorkOnLocalEventScheduling;

public interface IValidateWorkOnLocalEventScheduling
{
    Task Validate(Guid scheduleEventId);
}
