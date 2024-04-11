using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagerSystem.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;
    [Required(ErrorMessage = "Account is incorrect.")]

    public string? Username { get; set; }
    [Required(ErrorMessage = "Account is incorrect.")]

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Fullname { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
