namespace noberto.mealControl.Application.Utils.Validations.ValidateDay;

public interface IValidateTerm
{
    Task<TimeSpan> Validate(DateOnly date);
}
