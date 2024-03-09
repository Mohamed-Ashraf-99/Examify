using ExaminationBLL.Feature.Interface;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationBLL.ModelVM.GenerateVM;

namespace ExaminationBLL.Feature.Repository
{
    public class GenerateExamRepo : IGenerateExamRepo
    {
        private readonly ApplicationDbContext Db;
        public GenerateExamRepo(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public void Generate(GenerateExam generateExam)
        {
            var Course = Db.Courses.Where(a => a.CrsId==generateExam.CourseID).FirstOrDefault();
            foreach (var item in generateExam.StId)
            {
                if(item.IsSelected)
                {
                    Db.Database.ExecuteSql($"Exec [st_generateExam] {Course.CrsName},{generateExam.trueOrFalseCounnt},{generateExam.otherQuestionCount}");
                    var Exam = Db.Exams.OrderByDescending(a => a.ExId).FirstOrDefault();
                    Db.Database.ExecuteSql($"Exec [st_updateExam] {Exam.ExId},{Exam.ExName},{null},{item.StID}");

                }
            }

        }

        public GenerateExam Get(int id)
        {
            GenerateExam generateExam = new GenerateExam() { CourseID=id};
            generateExam.StId= new List<StudentGenerateExamVM>();
            var Courses = Db.Courses.Include(a => a.Sts).Where(c => c.CrsId==id).FirstOrDefault();
            var Students = Courses.Sts.ToList();
            foreach (var student in Students)
            {
                var user = Db.Users.Where(a => a.UserId==student.StId).FirstOrDefault();
                var StudentGenerateExamVM = new StudentGenerateExamVM() { StID=student.StId,StName=user.UserFname + user.UserLname};
                generateExam.StId.Add(StudentGenerateExamVM);
            }
            return generateExam;

        }
    }
}
