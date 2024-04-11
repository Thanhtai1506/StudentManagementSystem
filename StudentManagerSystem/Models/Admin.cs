using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Admin
{
    public string? AdminId { get; set; }

    public string? Fullname { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? AccountId { get; set; }

    public string? Role { get; set; }

    public virtual Account? Account { get; set; }
}
