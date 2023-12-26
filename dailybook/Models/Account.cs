using System;
using System.Collections.Generic;

namespace dailybook.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public bool Active { get; set; }

    public string Fullname { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual Role Role { get; set; } = null!;
}
