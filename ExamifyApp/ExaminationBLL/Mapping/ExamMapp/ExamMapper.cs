using ExaminationDAL.Entities;
using ExaminationBLL.ModelVM.ExamVM;
using ExaminationBLL.ModelVM.CourseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationBLL.ModelVM.ExamVM;

namespace ExaminationBLL.Mapping.ExamMapp
{
    public  class ExamMapper
    {
        public List<GetAllExamVM> Map(List<Exam> exams)
        { 
            
        List<GetAllExamVM> getAllExams = new List<GetAllExamVM>();

            foreach (var item in exams)
            {
                getAllExams.Add(new GetAllExamVM() { ExId = item.ExId , ExName = item.ExName , ExFinalGrade = item.ExFinalGrade ,St = item.St  });
            }

            return getAllExams;
        
        }

        public IEnumerable<GetExamByIdVM> Map(IEnumerable<Include> exam)
        {
            List<GetExamByIdVM> getExamByIdVM = new List<GetExamByIdVM>();
           foreach (var item in exam)
            {
                getExamByIdVM.Add(new GetExamByIdVM() {_questions= item.Qs, studentAnswer=item.StAnswer });
            }
            return getExamByIdVM;

        }

    }
}
