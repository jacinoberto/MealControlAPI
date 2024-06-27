namespace noberto.mealControl.Infra.Database.Utils.Validations;

public interface IValidateStrategy<T> where T : class
{
    Task Validate(T entity);
}
