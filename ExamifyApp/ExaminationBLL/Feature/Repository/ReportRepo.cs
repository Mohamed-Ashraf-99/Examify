using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.StudentMapp;
using ExaminationBLL.ModelVM.CourseVM;
using ExaminationBLL.ModelVM.ReportVM;
using ExaminationBLL.ModelVM.StudentVM;
using ExaminationDAL.Context;
using ExaminationDAL.Entities;
using ExaminationDAL.ModelVM.ReportVM;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Repository
{
  
    public class ReportRepo : IReportRepo
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly StudentMap studentMap;
        public ReportRepo(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext= applicationDbContext;
            studentMap= new StudentMap();
        }

       
        public List<StudentInfoDTO> GetStudentByDepartmentId(int id)
        {
            var Data = applicationDbContext.Database.SqlQuery<StudentInfoDTO>($"Exec  [st_getStudentInformationByDepartmentID] {id}").ToList();
    //            $"  SELECT s.st_id AS St_id,ISNULL(u.user_name, 'NA') AS UserName,ISNULL(u.email_address, 'NA') AS EmailAddress,ISNULL(u.user_fname, 'NA') AS UserFname, ISNULL(u.user_lname, 'NA') AS UserLname,ISNULL(s.st_address, 'NA') AS Address FROM Users u INNER JOIN Student s ON s.st_id = u.user_id  WHERE s.dept_id = {id}")
       
    //.ToList();
            return Data;
        }

        public List<st_getInstructorCoursesAndStudentsPerCourseDTO> st_getInstructorCoursesAndStudentsPerCourse(int id)
        {
            var Data = applicationDbContext.Database.SqlQuery<st_getInstructorCoursesAndStudentsPerCourseDTO>($"Exec  [st_getInstructorCoursesAndStudentsPerCourse] {id}").ToList();
            return Data;
        }

        public List<st_getStudentGradesInAllCoursesDTO> st_getStudentGradesInAllCourses(int id)
        {
            var Data = applicationDbContext.Database.SqlQuery<st_getStudentGradesInAllCoursesDTO>($"Exec  [st_getStudentGradesInAllCourses] {id}").ToList();
            return Data;


        }

        public List<st_getTopicsByCourseIDDTO> st_getTopicsByCourseID(int courseID)
        {
            var Data = applicationDbContext.Database.SqlQuery<st_getTopicsByCourseIDDTO>($"Exec  [st_getTopicsByCourseID] {courseID}").ToList();
            return Data;
        }

        public List<st_showExamWithStudentAnswersDTO> st_showExamWithStudentAnswers(int ExamID ,int StdID)
        {
            var Data = applicationDbContext.Database.SqlQuery<st_showExamWithStudentAnswersDTO>($"Exec  [st_showExamWithStudentAnswers] {ExamID},{StdID}").ToList();
            return Data;
        }


        public List<Exam> GetAllExamStudent(int id)
        {
            var Data = applicationDbContext.Exams.Where(a => a.StId==id).ToList();
            return Data;
        }

    }
}
