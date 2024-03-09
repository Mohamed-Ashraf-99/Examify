using ExaminationDAL.Entities;
using ExaminationBLL.ModelVM.CourseVM;
using ExaminationBLL.ModelVM.CourseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Mapping.CourseMapp
{
    public class CourseMapper
    {
        public List<GetAllCoursesVM> Map(List<Course> courses)
        {
            List<GetAllCoursesVM> getAllCoursesVMs = new List<GetAllCoursesVM>();
            foreach (Course course in courses)
            {
                getAllCoursesVMs.Add(new GetAllCoursesVM() { CrsId = course.CrsId,CrsDuration= course.CrsDuration,CrsName= course.CrsName,Ins= course.Ins,Topics= course.Topics });
            }
            return getAllCoursesVMs;
        }
        public GetCourseByIdVM Map(Course course)
        {       
            if (course == null)
            {
                return null;
            }          
            GetCourseByIdVM courseViewModel = new GetCourseByIdVM()
            {
                CrsId = course.CrsId,
                CrsName = course.CrsName,
                CrsDuration = course.CrsDuration,
                Ins = course.Ins, 
                Topics = course.Topics 
            };
            return courseViewModel;
        }

    }
}
