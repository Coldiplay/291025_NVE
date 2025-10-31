using _291025_NVE.CQRS.Model;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.Validators.Behavior
{
    public class ClientInfoBehavior<TRequest, TResponse>(IHttpContextAccessor httpContextAccessor) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string ipAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "";
            string userAgent = httpContextAccessor.HttpContext?.Request.Headers.UserAgent.ToString() ?? "";
            UserAdditionalInfo info = new(ipAddress, userAgent);

            var prop = typeof(TRequest).GetProperty("UserAdditionalInfo");
            if (prop != null)
            {
                prop.SetValue(request, info);
            }
            return await next();
        }
    }
}
