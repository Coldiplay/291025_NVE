using System;
using System.Collections.Generic;

namespace _291025_NVE.DB;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PaymentMethodId { get; set; }

    public int ShippingAdressId { get; set; }

    public virtual ICollection<ItemsToOrder> ItemsToOrders { get; set; } = new List<ItemsToOrder>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ShippingAdress ShippingAdress { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
