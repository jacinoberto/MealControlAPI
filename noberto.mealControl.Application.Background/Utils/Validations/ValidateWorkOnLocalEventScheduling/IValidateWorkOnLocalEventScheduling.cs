namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateWorkOnLocalEventScheduling;

public interface IValidateWorkOnLocalEventScheduling
{
    Task Validate(Guid scheduleEventId);
}
