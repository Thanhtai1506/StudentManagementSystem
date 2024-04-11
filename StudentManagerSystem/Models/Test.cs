using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Test
{
    public string TestId { get; set; } = null!;

    public string? TestName { get; set; }

    public string? CourseId { get; set; }

    public string? SubjectId { get; set; }

    public string? AcademicyearId { get; set; }

    public DateTime? TestDate { get; set; }

    public virtual Academicyear? Academicyear { get; set; }

    public virtual Course? Course { get; set; }
}
