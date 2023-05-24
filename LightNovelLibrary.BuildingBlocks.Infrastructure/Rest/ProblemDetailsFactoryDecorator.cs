using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Reflection;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

/// <summary>
/// 用于装饰.NET Core默认的Factory
/// </summary>
public class ProblemDetailsFactoryDecorator : ProblemDetailsFactory
{
    private readonly ProblemDetailsFactory _decorated;

    public ProblemDetailsFactoryDecorator(ProblemDetailsFactory decorated)
    {
        _decorated = decorated;
    }

    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, 
        string? detail = null, string? instance = null)
    {
        var feature = httpContext.Features.Get<IExceptionHandlerFeature>();
        if (feature?.Error != null)
        {
            if (feature.Error is BusinessException businessException)
            {
                var httpStatusAttribute = businessException.GetType().GetCustomAttribute<HttpStatusAttribute>();
                var status = httpStatusAttribute == null
                    ? (int)HttpStatusCode.InternalServerError : (int)httpStatusAttribute.StatusCode;
                httpContext.Response.StatusCode = status;
                return new ProblemDetails
                {
                    Status = status,
                    Detail = businessException.Message,
                    Extensions =
                    {
                        ["errorCode"] = businessException.ErrorCode
                    }
                };
            } else if (feature.Error is ValidationException validationException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = title,
                    Type = type,
                    Detail = detail,
                    Instance = instance,
                    Extensions =
                    {
                        ["errors"] = validationException.Errors.Select(e => new
                        {
                            property = e.PropertyName,
                            errorMessage = e.ErrorMessage,
                            attemptedValue = e.AttemptedValue
                        })
                    }
            };
            }
        }
        return _decorated.CreateProblemDetails(httpContext, statusCode, title, type, detail, instance);
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        return _decorated.CreateValidationProblemDetails(httpContext, modelStateDictionary, statusCode, title, type, detail, instance);
    }
}

