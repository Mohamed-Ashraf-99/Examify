using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.ReportVM
{
    public record st_showExamWithStudentAnswersDTO(Int64 Question,string? qs_title, string? Student_Answer, string? ModelAnswer, string? Student_name)
    {
    }
}
