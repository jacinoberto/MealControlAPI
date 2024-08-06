using noberto.mealControl.Application.Handler;

namespace noberto.mealControl.Application.Utils.Validations.ValidateInternalErrors;

public interface IValidateError
{
    InternalError Validate(Exception exception);
}
