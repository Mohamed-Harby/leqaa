using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Application.Behaviours;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("starting request {RequestType} in time {Now}",
         typeof(TRequest).Name,
         DateTime.Now);

        var response = await next();
        if (response.IsError)
        {
            _logger.LogError("Error in request {RequestType} with error: {Error} in time {Now}",
            typeof(TRequest).Name,
            response.Errors!.FirstOrDefault().Description,
            DateTime.Now);
        }
        _logger.LogInformation("Handled {RequestType} in time {Now}",
         typeof(TRequest).Name,
         DateTime.Now);

        return response;
    }
}