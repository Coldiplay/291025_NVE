using _291025_NVE.CQRS.Model;
using _291025_NVE.CQRS.Orders;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : Controller
    {
        private readonly IMediator mediator = mediator;

        [HttpPost("new")]
        public async Task<ActionResult> AddNewOrder(OrderToAddDTO order)
        {
            var command = new AddNewOrderCommand(order);
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
