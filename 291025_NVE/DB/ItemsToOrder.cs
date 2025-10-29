using System;
using System.Collections.Generic;

namespace _291025_NVE.DB;

public partial class ItemsToOrder
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int ItemCount { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
