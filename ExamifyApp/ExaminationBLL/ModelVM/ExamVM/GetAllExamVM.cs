using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.ExamVM
{
    public class GetAllExamVM
    {
        public int ExId { get; set; }

        public string? ExName { get; set; }

        public decimal? ExFinalGrade { get; set; }

        public virtual Student? St { get; set; }
    }
}
