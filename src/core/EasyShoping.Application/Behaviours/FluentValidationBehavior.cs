﻿using FluentValidation;
using MediatR;

namespace EasyShoping.Application.Behaviours;

public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures =validationResults
            .SelectMany(er=>er.Errors)
            .Where(f=>f != null)
            .ToList();
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next();
    }
}
