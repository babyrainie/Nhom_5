using System;
using System.Collections.Generic;

namespace dailybook.Models;

public partial class Customer
{
    public int CusId { get; set; }

    public string Fullname { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Ava { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? LocationId { get; set; }

    public int? Dis { get; set; }

    public int? Ward { get; set; }

    public DateTime? CreateDate { get; set; }

    public string Pass { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
