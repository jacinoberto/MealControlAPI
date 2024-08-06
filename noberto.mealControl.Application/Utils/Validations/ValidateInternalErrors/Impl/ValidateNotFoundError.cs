using noberto.mealControl.Application.Handler;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Application.Utils.Validations.ValidateInternalErrors.Impl;

public class ValidateNotFoundError : IValidateError
{
    private readonly InternalError _error;

    public ValidateNotFoundError(InternalError error)
    {
        _error = error;
    }

    public InternalError Validate(Exception exception)
    {
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(EntityNotFoundException))
        {
            _error.Message = exception.Message;
            _error.StatusCode = 404;
            _error.Date = DateTime.Now;
        }

        return _error;
    }
}
