using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.ExamVM
{
    public class GetExamByIdVM
    {
      public Question _questions{get;set;}
      public int ?studentAnswer { get; set; }
    }
}
