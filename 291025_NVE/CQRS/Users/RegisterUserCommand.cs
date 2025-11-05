using _291025_NVE.CQRS.Model;
using _291025_NVE.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.CQRS.Users
{
    public class RegisterUserCommand : AdditionInfoUser, IRequest
    {
        public UserToAddDTO User { get; set; }

        public class RegisterUserCommandHandler() : IRequestHandler<RegisterUserCommand, Unit>
        {
            public async Task<Unit> HandleAsync(RegisterUserCommand request, CancellationToken ct = default)
            {
                throw new Exception("Тест");
                //if (await db.Users.AnyAsync(u => u.Id == request.User.Id))
                //    throw new Exception();

                //db.Users.Add((User)request.User);
                //await db.SaveChangesAsync();
                //return Unit.Value;
            }
        }
    }
}
