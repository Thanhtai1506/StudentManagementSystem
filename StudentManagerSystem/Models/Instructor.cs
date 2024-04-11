using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Instructor
{
    public string InstructorId { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? AccountId { get; set; }

    public string? Address { get; set; }

    public string? ClassId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Class? Class { get; set; }
}
