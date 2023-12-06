using Auctria.EcommerceStore.Core.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace Auctria.EcommerceStore.Web.API.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> logger =  logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        logger.LogError(
            exception,
            "Can not process request on machine - {MachineName}. TraceId: {TraceId})",
            Environment.MachineName,
            traceId);

        var (statusCode, title) = MapException(exception);

        await Results.Problem(
            title: title,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>
            {
                { "traceId", traceId}
            }
        ).ExecuteAsync(httpContext);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        string exceptionMessage = exception?.InnerException?.Message ?? exception?.Message ?? "";

        return exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, exceptionMessage),
            InsufficientStockException => (StatusCodes.Status404NotFound, exceptionMessage),
            NotFoundException => (StatusCodes.Status404NotFound, exceptionMessage),
            _ => (StatusCodes.Status500InternalServerError, exceptionMessage)
        };
    }
}
