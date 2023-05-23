using FluentValidation;
using MediatR;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;

/// <summary>
/// MediatR校验拦截器
/// </summary>
public class ValidateRequestBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidateRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            //调用所有的校验器，校验失败抛出异常
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var errors = validationResults.SelectMany(r => r.Errors).Where(e => e is not null).ToList();
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
        return await next();
    }
}