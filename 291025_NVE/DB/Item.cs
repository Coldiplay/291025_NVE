using System;
using System.Collections.Generic;

namespace _291025_NVE.DB;

public partial class Item
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ItemsToOrder> ItemsToOrders { get; set; } = new List<ItemsToOrder>();
}
