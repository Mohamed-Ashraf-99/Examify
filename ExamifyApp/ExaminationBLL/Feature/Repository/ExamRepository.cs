using ExaminationDAL.Entities;
using ExaminationDAL.Context;
using ExaminationBLL.Feature.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExaminationBLL.Feature.Repository;

public class ExamRepository : IExamRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ExamRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Exam? GetExamById(int id)
        => _applicationDbContext.Exams
            .Include(e => e.Includes)
            .ThenInclude(i => i.Qs)
            .ThenInclude(q => q.MultipleChoices)
            .FirstOrDefault(e => e.ExId == id);

    public string StoreStudentExamAnswers(int examId, string stName, int? answer1, int? answer2,
        int? answer3, int? answer4, int? answer5, int? answer6, int? answer7, int? answer8,
        int? answer9, int? answer10)
        => _applicationDbContext.Database.ExecuteSql(
            $"st_storeStudentExamAnswers @ex_id={examId}, @st_name={stName}, @answer1={answer1}, @answer2={answer2}, @answer3={answer3}, @answer4={answer4}, @answer5={answer5}, @answer6={answer6}, @answer7={answer7}, @answer8={answer8}, @answer9={answer9}, @answer10={answer10}").ToString();

    public int CorrectExam(int examId, string stName)
        => _applicationDbContext.Database.ExecuteSql(
            $"st_correctExam @exam_id={examId}, @student_name={stName}");

    
}