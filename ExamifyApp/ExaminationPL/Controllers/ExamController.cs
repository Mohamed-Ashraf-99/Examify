using ExaminationBLL.Feature.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationPL.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamRepo examRepo;
        public ExamController(IExamRepo _examRepo)
        {
            examRepo = _examRepo;
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = examRepo.GetAllExam();
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult getExamById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = examRepo.GetExamById(id);
            return View(data);
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult DeleteExam(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                examRepo.DeleteExam(id);
            return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
