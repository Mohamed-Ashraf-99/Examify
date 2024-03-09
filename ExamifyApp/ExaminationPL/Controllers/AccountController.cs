
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.ModelVM.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepo _loginRepo;
        public AccountController(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var user = _loginRepo.IsValid(loginVM);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetInt32("RoleId", (int)user.RoleId);
                    if (user.RoleId == 2)
                    {
                        //Go to Pre Exam Page
                        return RedirectToAction("StudentProfile", "PreExam");
                    }
                    else
                    {
                        return RedirectToAction("GetAll", "Student");
                    }
                }
            }
            return View(loginVM);
        }

        #endregion

        // #region Log out
        // public IActionResult Logout()
        // {
        //     return View();
        // }
        // #endregion


    }
}
