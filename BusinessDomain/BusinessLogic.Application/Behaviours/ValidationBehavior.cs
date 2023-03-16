using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BusinessLogic.Application.Behaviours;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
where TResponse : IErrorOr
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            ValidationResult[] validationResults = await Task.
            WhenAll(
                _validators.Select(v => v.ValidateAsync(
                context,
                cancellationToken)));

            List<Error> errors = validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList().ConvertAll(
                validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage)
            );
            if (errors.Any())
            {
                return (dynamic)errors;
            }
        }
        return await next();
    }
}
