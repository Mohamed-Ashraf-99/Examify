using ExaminationDAL.Entities;
using ExaminationBLL.Feature.Interface;
using ExaminationDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using ExaminationBLL.ModelVM.UserVM;

namespace ExaminationPL.Controllers;

public class CurrentExamController : Controller
{
    private readonly IExamRepository _examRepository;
    private readonly IStudentRepo _studentRepo;

    public CurrentExamController(IExamRepository examRepository, IStudentRepo studentRepo)
    {
        _examRepository = examRepository;
        _studentRepo = studentRepo;
    }

    public IActionResult Index(int id)
    {
        int? UserId = HttpContext.Session.GetInt32("UserId");
        int? RoleID = HttpContext.Session.GetInt32("RoleId");
        if (UserId != null && RoleID==2)
        {
            var exam = _examRepository.GetExamById(id);
        if (exam is null)
            return NotFound();

        return View(exam);
        }
        return RedirectToAction("Login", "Account");
    }

    [HttpPost]
    public IActionResult Index(Exam exam)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        int? roleID = HttpContext.Session.GetInt32("RoleId");
        if (userId != null && roleID==2)
        {
            var student = _studentRepo.GetStudentById(userId);
            try
            {
                List<int?> answers = [null, null, null, null, null, null, null, null, null, null];
                var count = 0;
                foreach (var include in exam.Includes)
                {
                    if (include.StAnswer is not null)
                        answers[count] = include.StAnswer;
                    count++;
                }

                _examRepository.StoreStudentExamAnswers(exam.ExId, $"{student.UserFname} {student.UserLname}", answers[0], answers[1],
                    answers[2], answers[3], answers[4], answers[5], answers[6], answers[7], answers[8],
                    answers[9]);

                _examRepository.CorrectExam(exam.ExId, student.UserName);
            }
            catch (Exception e)
            {
                Exam? showedExam = _examRepository.GetExamById(exam.ExId);
                return View(showedExam);
            }

            return RedirectToAction("Index", "Result", new { id = exam.ExId });
        }
        return RedirectToAction("Login", "Account");

    }
}