using ExaminationDAL.Entities;
using ExaminationDAL.Entities;

namespace ExaminationBLL.Feature.Interface;

public interface IExamRepository
{
    Exam? GetExamById(int id);

    string StoreStudentExamAnswers(int examId, string stName, int? answer1, int? answer2, int? answer3,
        int? answer4, int? answer5, int? answer6, int? answer7, int? answer8, int? answer9, int? answer10);

    int CorrectExam(int examId, string stName);
}