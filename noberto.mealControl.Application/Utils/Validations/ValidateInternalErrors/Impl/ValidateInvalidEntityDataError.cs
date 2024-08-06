using noberto.mealControl.Application.Handler;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Application.Utils.Validations.ValidateInternalErrors.Impl;

public class ValidateInvalidEntityDataError : IValidateError
{
    private readonly InternalError _error;

    public ValidateInvalidEntityDataError(InternalError error)
    {
        _error = error;
    }

    public InternalError Validate(Exception exception)
    {
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(InvalidEntityDataException))
        {
            _error.Message = exception.Message;
            _error.StatusCode = 400;
            _error.Date = DateTime.Now;
        }

        return _error;
    }
}
