using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Feature.Repository;
using ExaminationBLL.Helper;
using ExaminationBLL.ModelVM.StudentVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examination.PL.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IDepartmentRepo departmentRepo;

        public StudentController(IStudentRepo studentRepo, IDepartmentRepo departmentRepo )
        {
            _studentRepo = studentRepo;
             this.departmentRepo =  departmentRepo;
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = _studentRepo.getAllStudent();
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult getById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = _studentRepo.GetStudentById(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult DeleteInstructorByID(int Id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                _studentRepo.DeleteInstructorByID(Id);
            return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");

        }


        public IActionResult InsertStudent()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                ViewData["Department"] = new SelectList(departmentRepo.GetAllDepartments(), "DeptId", "DeptName");

            return View();
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult InsertStudent(InsertStudentVM insertStudentVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                insertStudentVM.StImg = FileUploader.UploadFile("StudentsImages", insertStudentVM.Image);

                _studentRepo.InsertStudent(insertStudentVM);
                return RedirectToAction("getAll");
            }
            ViewData["Department"] = new SelectList(departmentRepo.GetAllDepartments(), "DeptId", "DeptName");

            return View(insertStudentVM);
            }
            return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                ViewData["Department"] = new SelectList(departmentRepo.GetAllDepartments(), "DeptId", "DeptName");

            var Data = _studentRepo.GetStudentDataById(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult Edit(EditStudentVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                    model.StImg = FileUploader.UploadFile("StudentsImages", model.Image);

                    _studentRepo.Edit(model);
                return RedirectToAction("getAll");

            }

            ViewData["Department"] = new SelectList(departmentRepo.GetAllDepartments(), "DeptId", "DeptName");
            return View(model);
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
