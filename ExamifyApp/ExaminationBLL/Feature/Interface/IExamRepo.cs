using ExaminationBLL.ModelVM.ExamVM;
using ExaminationBLL.ModelVM.ExamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExaminationBLL.Feature.Interface
{
    public interface IExamRepo
    {
      
         List<GetAllExamVM> GetAllExam();

        IEnumerable<GetExamByIdVM> GetExamById(int examid);

        void DeleteExam (int examId);

        
       
    }
}
