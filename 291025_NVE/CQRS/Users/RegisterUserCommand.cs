using _291025_NVE.CQRS.Model;
using _291025_NVE.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.CQRS.Users
{
    public class RegisterUserCommand : AdditionInfoUser, IRequest<Unit>
    {
        public UserToAddDTO User { get; set; }

        public class RegisterUserCommandHandler(DbFor291025Context db) : IRequestHandler<RegisterUserCommand, Unit>
        {
            public async Task<Unit> HandleAsync(RegisterUserCommand request, CancellationToken ct = default)
            {
                if (await db.Users.AnyAsync(u => u.Id == request.User.Id))
                    throw new Exception();

                db.Users.Add((User)request.User);
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
