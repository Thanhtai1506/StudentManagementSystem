using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ClassId { get; set; }

    public string? SubjectId { get; set; }

    public string? AccountId { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }



    public virtual Account? Account { get; set; }

    public virtual Result? Result { get; set; }
}
