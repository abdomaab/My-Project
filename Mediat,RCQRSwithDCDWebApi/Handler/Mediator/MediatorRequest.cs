using FluentValidation;
using MediatR;

namespace Handler.Mediator
{
    public class MediatorRequest<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public MediatorRequest(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(v => v.Validate(context))
                                      .SelectMany(v => v.Errors)
                                      .Where(v => v != null)
                                      .ToList();
            
            if (failures.Any())
                throw new ValidationException(failures);
           
            return next();
        }
    }
}
