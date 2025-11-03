using _291025_NVE.CQRS.Model;
using _291025_NVE.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _291025_NVE.CQRS.Orders
{
    public class AddNewOrderCommand(OrderToAddDTO order) : AdditionInfoUser, IRequest<Unit>
    {
        public readonly OrderToAddDTO order = order;

        public class AddNewOrderCommandHandler(DbFor291025Context db) : IRequestHandler<AddNewOrderCommand, Unit>
        {
            public async Task<Unit> HandleAsync(AddNewOrderCommand request, CancellationToken ct = default)
            {
                var order = new Order
                {
                    UserId = request.order.User_Id,
                    PaymentMethodId = request.order.PaymentMethod_Id,
                };
                var ship_adress_dto = request.order.ShippingAdress;
                var shipping_adress = await db.ShippingAdresses.FirstOrDefaultAsync(a => a.House == ship_adress_dto.House 
                && a.City == ship_adress_dto.City
                && a.PostalCode == ship_adress_dto.PostalCode
                && a.Street == ship_adress_dto.Street, ct);
                if (shipping_adress is null)
                {
                    shipping_adress = (ShippingAdress)ship_adress_dto;
                    var res = await db.ShippingAdresses.AddAsync(shipping_adress);
                    order.ShippingAdressId = res.Entity.Id;
                }
                else
                    order.ShippingAdressId = shipping_adress.Id;

                var orderInDB = db.Orders.Add(order);

                foreach (var r in request.order.Items)
                {
                    db.ItemsToOrders.Add(new ItemsToOrder { ItemCount = r.ItemCount, ItemId = r.ItemId, OrderId = orderInDB.Entity.Id});
                }

                await db.SaveChangesAsync(ct);

                return Unit.Value;
            }
        }
    }
}
