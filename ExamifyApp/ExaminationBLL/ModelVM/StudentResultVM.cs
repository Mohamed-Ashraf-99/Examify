using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM
{
    public class StudentResultVM
    {
        public string ExamName { get; set; }
        public decimal? FinallDegree {  get; set; }
        public Student student { get; set; }
        
    }
}
