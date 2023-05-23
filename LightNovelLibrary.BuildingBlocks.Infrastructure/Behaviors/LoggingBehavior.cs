using MediatR;
using Microsoft.Extensions.Logging;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;

public class LoggingBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {type}", request.GetType());
        request.GetType().GetProperties().ToList()
            .ForEach(p => _logger.LogInformation("{Key} : {Value}", p.Name, p.GetValue(request)));
        try 
        {
            var result = await next();
            _logger.LogInformation("Handled {type} Success", request.GetType());
            return result;
        } catch (Exception ex)
        {
            _logger.LogError(ex, "Handled {type} Error", request.GetType());
            throw;
        }
    }
}

