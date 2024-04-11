using System;
using System.Collections.Generic;

namespace StudentManagerSystem.Models;

public partial class Academicyear
{
    public string AcademicyearId { get; set; } = null!;

    public int? Year { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
