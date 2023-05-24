using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

/// <summary>
/// 全局异常处理中间件
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        } catch (Exception ex)
        {
            handleException(context, ex);
        }
    }

    private void handleException(HttpContext context, Exception ex)
    {
        switch(ex)
        {
            case BusinessException businessException:

                break;
        }
    }
}

