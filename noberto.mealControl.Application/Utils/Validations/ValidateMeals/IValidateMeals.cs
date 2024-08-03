namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals;

public interface IValidateMeals<T>
{
    Task Validate(T t);
}
