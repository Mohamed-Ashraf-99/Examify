using ExaminationBLL.Feature.Interface;
using ExaminationBLL.ModelVM;
using ExaminationDAL.Context;
using ExaminationDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationBLL.Feature.Interface;

namespace ExaminationBLL.Feature.Repository
{
    public class GetExamResultRepo : IGetExamResultRepo
    {
        private readonly ApplicationDbContext Db;
        public GetExamResultRepo(ApplicationDbContext _Db)
        {
            this.Db = _Db;
        }

        public StudentResultVM Get(int examID, int? studentID)
        {
            var studentResultVM = new StudentResultVM();
            studentResultVM.student = Db.Students.Include(a=>a.St).Where(student => student.StId == studentID).FirstOrDefault();
            var Exam = Db.Exams.Where(a=>a.ExId == examID).FirstOrDefault();
            studentResultVM.ExamName = Exam.ExName;
            studentResultVM.FinallDegree = Exam.ExFinalGrade;
            return studentResultVM;

        }
    }
}
