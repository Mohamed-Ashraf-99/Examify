﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace ExaminationDAL.Entities;

public partial class Student
{
    public int StId { get; set; }

    public string? StAddress { get; set; }

    public int? DeptId { get; set; }

    public string? StImg { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual User St { get; set; } = null!;

    public virtual ICollection<Course> Crs { get; set; } = new List<Course>();
}