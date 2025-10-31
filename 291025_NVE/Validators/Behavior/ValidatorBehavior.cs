using MyMediator.Interfaces;
using MyMediator.Types;
using System.ComponentModel.DataAnnotations;

namespace _291025_NVE.Validators.Behavior
{
    public interface IValidator<TRequest>
    {
        Task<IEnumerable<string>> ValidateAsync(TRequest request, CancellationToken ct);
    }

    public class ValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : 
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            if (!_validators.Any())
                return await next();

            List<string> failures = [];
            foreach (var validator in _validators)
            {
                var res = await validator.ValidateAsync(request, ct);
                if (res is not null)
                    failures.AddRange(res);
            }


            if (failures.Count != 0)
                throw new ValidationException(string.Join(";", failures));
            else
                return await next();
        }
    }
}
