using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Class
{
    public string ClassId { get; set; } = null!;

    public string? CourseId { get; set; }

    public string? ClassName { get; set; }

    public string? AcademicyearId { get; set; }

    public virtual Academicyear? Academicyear { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
