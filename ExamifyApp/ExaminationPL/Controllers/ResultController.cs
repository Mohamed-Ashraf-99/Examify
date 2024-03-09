using ExaminationBLL.Feature.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationPL.Controllers
{
    public class ResultController : Controller
    {
        private readonly IGetExamResultRepo _resultRepo;
        public ResultController(IGetExamResultRepo _resultRepo)
        {
            this._resultRepo = _resultRepo;
        }
        public IActionResult Index(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==2)
            {
                return View(_resultRepo.Get(id, UserId));
            }
            return RedirectToAction("Login", "Account");
        }

   
}
}
