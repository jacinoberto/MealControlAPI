using noberto.mealControl.Application.Handler;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Application.Utils.Validations.ValidateInternalErrors.Impl;

public class ValidateServerError : IValidateError
{
    private readonly InternalError _error;

    public ValidateServerError(InternalError error)
    {
        _error = error;
    }

    public InternalError Validate(Exception exception)
    {
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(ServerErrorException))
        {
            _error.Message = exception.Message;
            _error.StatusCode = 500;
            _error.Date = DateTime.Now;
        }

        return _error;
    }
}
