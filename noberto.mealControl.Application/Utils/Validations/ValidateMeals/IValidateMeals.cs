namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals;

public interface IValidateMeals<TUpdate, TReturn>
{
    Task<IEnumerable<TReturn>> Validate(TUpdate t);
}
