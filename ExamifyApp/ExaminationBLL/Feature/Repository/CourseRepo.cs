using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.CourseMapp;
using ExaminationDAL.Context;
using ExaminationBLL.ModelVM.CourseVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ExaminationBLL.ModelVM.CourseVM;
using ExaminationDAL.Entities;
using ExaminationBLL.ModelVM.CourseVM;
using System.Data;

namespace ExaminationBLL.Feature.Repository
{
    public class CourseRepo : ICourseRepo
    {
       
        private readonly ApplicationDbContext Db;
        private readonly CourseMapper courseMapper;
        public CourseRepo(ApplicationDbContext _db)
        {
            Db = _db;
            courseMapper = new CourseMapper();
        }

        public void DeleteCourse(int courseId)
        {
            Db.Database.ExecuteSqlRaw("EXEC st_deleteFromCourse @p0", courseId);
        }
        public void EditCourse(int courseId, string courseName, int courseDuration)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[st_updateCourse] @course_id, @course_name, @course_duration",
                    new SqlParameter("@course_id", courseId),
                    new SqlParameter("@course_name", courseName),
                    new SqlParameter("@course_duration", courseDuration));                      
        }

        public void EditCourse(EditCourseVM model)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[st_updateCourse] @course_id, @course_name, @course_duration",
                    new SqlParameter("@course_id", model.CrsId),
                    new SqlParameter("@course_name", model.CrsName),
                    new SqlParameter("@course_duration", model.CrsDuration)); 
        }

        public List<GetAllCoursesVM> GetAll()
        {
            var Data = Db.Courses.Include(a => a.Ins).ThenInclude(a=>a.Ins).ToList();
            foreach (var data in Data)
            {
                data.Topics = Db.Topics.Where(a => a.CrsId == data.CrsId).ToList();
            }
            return courseMapper.Map(Data);
        }

       

        public GetCourseByIdVM getCourseById(int courseId)
        {
            var course = Db.Courses
                .Include(a => a.Ins).ThenInclude(e=>e.Ins)
                .Include(a => a.Topics)
                .SingleOrDefault(a => a.CrsId == courseId);

            if (course == null)
            {
                return null;
            }

            return courseMapper.Map(course);
        }

        public void InsertCourse(InsertCourseVM insertCourseVM)
        {
            // Assuming st_insertIntoCourse stored procedure is modified to return the ID of the inserted course
           
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[st_insertIntoCourse]  @course_name, @course_duration",
                     new SqlParameter("@course_name", insertCourseVM.CrsName),
                     new SqlParameter("@course_duration", insertCourseVM.CrsDuration));
            var lastcourse = Db.Courses.OrderByDescending(a => a.CrsId).FirstOrDefault();

            foreach (var item in insertCourseVM.Topics)
            {
               
                Db.Database.ExecuteSqlRaw("INSERT INTO Topic (topic_name, crs_id) VALUES (@topicName, @crsId)",
                    new SqlParameter("@topicName", item.TopicName),
                    new SqlParameter("@crsId", lastcourse.CrsId));
            }
        }

    }
}
