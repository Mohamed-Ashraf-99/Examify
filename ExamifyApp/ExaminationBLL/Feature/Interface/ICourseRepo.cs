using ExaminationBLL.ModelVM.CourseVM;
using ExaminationBLL.ModelVM.CourseVM;
using ExaminationBLL.ModelVM.CourseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface ICourseRepo
    {
        List<GetAllCoursesVM> GetAll();
        void DeleteCourse(int examId);
        void EditCourse(EditCourseVM model );
        GetCourseByIdVM getCourseById(int id);
        void InsertCourse(InsertCourseVM insertStudentVM);

    }
}
