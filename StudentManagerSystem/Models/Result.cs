using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Result
{
    public string StudentId { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? ClassId { get; set; }

    public string? SubjectId { get; set; }

    public int? MediumScore { get; set; }

    public int? Testscore1st { get; set; }

    public int? Testscore2nd { get; set; }

    public int? FinalGrade { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject? Subject { get; set; }
}
