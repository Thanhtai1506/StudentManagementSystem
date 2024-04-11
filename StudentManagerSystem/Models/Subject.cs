using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string? SubjectName { get; set; }

    public string? InstructorId { get; set; }

    public string? CourseId { get; set; }

    public string? InstructorName { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
