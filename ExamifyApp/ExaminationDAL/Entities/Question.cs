﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace ExaminationDAL.Entities;

public partial class Question
{
    public int QsId { get; set; }

    public string? QsTitle { get; set; }

    public string? QsType { get; set; }

    public string? QsDifficulty { get; set; }

    public decimal? QsGrade { get; set; }

    public int? ModelAnswer { get; set; }

    public int? CrsId { get; set; }

    public virtual Course? Crs { get; set; }

    public virtual ICollection<Include> Includes { get; set; } = new List<Include>();

    public virtual ICollection<MultipleChoice> MultipleChoices { get; set; } = new List<MultipleChoice>();
}