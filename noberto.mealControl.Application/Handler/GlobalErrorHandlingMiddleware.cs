using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using noberto.mealControl.Application.Utils.Validations.ValidateInternalErrors;

namespace noberto.mealControl.Application.Handler;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IEnumerable<IValidateError> _errors;

    public GlobalErrorHandlingMiddleware(RequestDelegate next, IEnumerable<IValidateError> errors)
    {
        _next = next;
        _errors = errors;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(context, ex);
        }
    }

    private async Task<Task> HandlerExceptionAsync(HttpContext context, Exception exception)
    {
        InternalError internalError = new();

        foreach (var error in _errors)
        {
            internalError = error.Validate(exception);
        }

        var result = JsonSerializer.Serialize(new { internalError.Message, internalError.StatusCode, internalError.Date });

        context.Response.ContentType = "text/json";
        context.Response.StatusCode = (int)internalError.StatusCode;

        return context.Response.WriteAsync(result);
    }
}
