using ExaminationBLL.Feature.Interface;
using ExaminationBLL.ModelVM.GenerateVM;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationPLL.Controllers.Admin
{
    public class GenerateExamController : Controller
    {
        private readonly IGenerateExamRepo generateExamRepo;
        public GenerateExamController(IGenerateExamRepo generateExamRepo)
        {
            this.generateExamRepo = generateExamRepo;
        }
        public IActionResult Index(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = generateExamRepo.Get(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult Index(GenerateExam generateExam)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                generateExamRepo.Generate(generateExam);
                return RedirectToAction("getAll", "Student");
            }
            return View(generateExam);
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
