using _291025_NVE.CQRS.Orders;
using _291025_NVE.DB;
using _291025_NVE.Validators.Behavior;
using Microsoft.EntityFrameworkCore;

namespace _291025_NVE.Validators
{
    public class AddNewOrderCommandValidator : IValidator<AddNewOrderCommand>
    {
        public async Task<IEnumerable<string>> ValidateAsync(AddNewOrderCommand request, CancellationToken ct)
        {
            List<string> errors = [];
            var db = new DbFor291025Context();

            foreach (var s in request.order.Items)
            {
                var item = await db.Items.FirstOrDefaultAsync(i => i.Id == s.ItemId, ct);
                if (item is null)
                {
                    errors.Add($"Нет товара в базе данных");
                    break;
                }
                if (item.StockQuantity < s.ItemCount)
                {
                    errors.Add($"У нас нет такого количества товара {item.Title}");
                }
            }

            if (await db.Users.AnyAsync(u => u.Id == request.order.User_Id, ct))
                errors.Add("Нет такого пользователя");






            return errors;
        }
    }
}
