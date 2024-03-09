using ExaminationBLL.Feature.Repository;
using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL.Entities;

namespace ExaminationBLL.Feature.Interface
{
    public interface IpreExam
    {
        Exam GetExamByStudentId(int? StudentId);

        Student GetStudentById(int? StudentId);

        Exam GetExamByStudentId(int id);

        List<Exam> GetExamList(int? StudentId);
    }
}
