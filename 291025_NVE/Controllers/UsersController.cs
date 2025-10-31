using _291025_NVE.CQRS.Model;
using _291025_NVE.CQRS.Users;
using _291025_NVE.DB;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : Controller
    {
        private readonly IMediator mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserToAddDTO user)
        {
            var command = new RegisterUserCommand(user);
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
