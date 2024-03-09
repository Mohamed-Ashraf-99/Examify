using ExaminationBLL.ModelVM.ReportVM;
using ExaminationBLL.ModelVM.StudentVM;
using ExaminationDAL.Entities;
using ExaminationDAL.ModelVM.ReportVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface IReportRepo
    {
        List<StudentInfoDTO> GetStudentByDepartmentId(int id);
        List<st_getStudentGradesInAllCoursesDTO> st_getStudentGradesInAllCourses(int id);
        List<st_getInstructorCoursesAndStudentsPerCourseDTO> st_getInstructorCoursesAndStudentsPerCourse(int id);
        List<st_getTopicsByCourseIDDTO> st_getTopicsByCourseID(int courseID);
        List<st_showExamWithStudentAnswersDTO> st_showExamWithStudentAnswers(int ExamID, int StdID);
        List<Exam> GetAllExamStudent(int id);
    }
}
