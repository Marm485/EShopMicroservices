using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[START] Handling request={RequestType}, response={ResponseType}, request data={RequestData}",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            request);

        var sw = Stopwatch.StartNew();

        var response = await next();

        sw.Stop();

        logger.LogInformation(
            "[END] Handled request={RequestType}, response={ResponseType}, response data={ResponseData},elapsed={ElapsedMilliseconds}ms",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            response,
            sw.ElapsedMilliseconds);

        return response;
    }
}
