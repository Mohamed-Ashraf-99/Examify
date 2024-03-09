using ExaminationBLL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface IGetExamResultRepo
    {
        StudentResultVM Get(int examID, int? studentID);
    }
}
