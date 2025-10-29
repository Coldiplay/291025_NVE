using System;
using System.Collections.Generic;

namespace _291025_NVE.DB;

public partial class User
{
    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string? Info { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
