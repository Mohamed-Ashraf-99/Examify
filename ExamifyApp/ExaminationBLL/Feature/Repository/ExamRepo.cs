using ExaminationDAL.Context;
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.ExamMapp;
using ExaminationBLL.Mapping.CourseMapp;
using ExaminationBLL.ModelVM.ExamVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationBLL.ModelVM.ExamVM;
using ExaminationDAL.Entities;

namespace ExaminationBLL.Feature.Repository
{
    public class ExamRepo : IExamRepo
    {
        private readonly ApplicationDbContext Db;  
        private readonly ExamMapper examMapper;
        public ExamRepo(ApplicationDbContext _db)
        {
            Db = _db;
            examMapper = new ExamMapper();
        }

        public void DeleteExam(int examId)
        {

           Db.Database.ExecuteSqlRaw("EXEC st_deleteFromExam @p0", examId);
        }

        public List<GetAllExamVM> GetAllExam()
        {
            var examList = Db.Exams.Include(a => a.St).ThenInclude(a => a.St).ToList();

            return examMapper.Map(examList);
        }

        public IEnumerable<GetExamByIdVM> GetExamById(int examid)
        {
            var Data = Db.Includes
              .Where(i => i.ExId == examid)
              .Include(i => i.Qs.MultipleChoices)
              .ToList();
            return examMapper.Map(Data);
        }
    }
      
        
    
}
