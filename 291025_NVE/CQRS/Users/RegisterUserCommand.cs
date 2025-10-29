using _291025_NVE.CQRS.Model;
using _291025_NVE.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.CQRS.Users
{
    public class RegisterUserCommand(UserDTO user) : IRequest
    {
        private readonly UserDTO user = user;

        public class RegisterUserCommandHandler(DbFor291025Context db) : IRequestHandler<RegisterUserCommand, Unit>
        {
            public Task<Unit> HandleAsync(RegisterUserCommand request, CancellationToken ct = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}
