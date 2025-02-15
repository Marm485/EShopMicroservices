using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler;

public class CustomExceptionHandler
    (ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {message}.", exception.Message);

        (string Detail, string Title, int StatusCode) = exception switch
        {
            ValidationException ex => (
                ex.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest),

            NotFoundException ex => (
                ex.Message, 
                exception.GetType().Name, 
                context.Response.StatusCode = StatusCodes.Status404NotFound),

            BadRequestException ex => (
                ex.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest),

            _ => (exception.Message, 
                exception.GetType().Name, 
                StatusCodes.Status500InternalServerError)
        };

        var problemDetails = new ProblemDetails
        {
            Title = Title,
            Detail = Detail,
            Status = StatusCode,
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
        }

        await context.Response.WriteAsJsonAsync(problemDetails);

        return true;
    }
}
