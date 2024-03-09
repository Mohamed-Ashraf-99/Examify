using ExaminationBLL.ModelVM.CourseVM;
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Feature.Repository;
using ExaminationBLL.ModelVM.CourseVM;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationPL.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;
        public CourseController(ICourseRepo _courseRepo)
        {
            courseRepo = _courseRepo;
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = courseRepo.GetAll();
            return View(Data);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult DeleteCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                courseRepo.DeleteCourse(id);
            return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = courseRepo.getCourseById(id);
            EditCourseVM editCourseVM = new EditCourseVM()
            {
                CrsId = Data.CrsId,
                CrsDuration =(int) Data.CrsDuration,
                CrsName = Data.CrsName,
            };
            return View(editCourseVM);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult EditCourse(EditCourseVM editCourseVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                //2 
                if (ModelState.IsValid) 
            {
                courseRepo.EditCourse(editCourseVM);
                return RedirectToAction("getAll");
            }
            return View(editCourseVM);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult getCourseById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = courseRepo.getCourseById(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult InsertCourse(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult InsertCourse(InsertCourseVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                //2 
                if (ModelState.IsValid)
            {
                courseRepo.InsertCourse(model);
                return RedirectToAction("getAll");
            }
            return View(model);
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
