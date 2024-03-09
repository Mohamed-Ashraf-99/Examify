using ExaminationDAL.Entities;
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.DepartmentMapp;
using Microsoft.AspNetCore.Mvc;
using ExaminationBLL.ModelVM.DepartmentModelVM;
using ExaminationBLL.ModelVM.UserVM;

namespace ExaminationPL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _departmentRepo;
        private readonly DepartmentMapper _departmentMapper;

        public DepartmentController(IDepartmentRepo departmentRepo, DepartmentMapper departmentMapper)
        {
            _departmentMapper = departmentMapper;
            _departmentRepo = departmentRepo;
        }

        public IActionResult DisplayDepartments()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                List<DepartmentVM> departments = new List<DepartmentVM>();
                departments = _departmentRepo.GetAllDepartments();
                return View("DisplayDepartments", departments);

            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult GetEmployeeById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var department = _departmentRepo.GetById(id);
            return View("GetEmployeeById", department);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Create()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var departmentVM = new DepartmentVM()
                {
                    Instructors = _departmentRepo.GetAllInstructors()
                };
                return View("Create", departmentVM);
            }
            return RedirectToAction("Login", "Account");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentVM department)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (!ModelState.IsValid)
                {
                    department.Instructors = _departmentRepo.GetAllInstructors();
                    return View(department);
                }

                var departmentEntity = new Department
                {
                    DeptName = department.DeptName,
                    DeptDesc = department.DeptDesc,
                    DeptLocation = department.DeptLocation,
                    DeptMgrId = department.DeptMgrId,
                    MgrHireDate = department.MgrHireDate
                };

                _departmentRepo.AddDepartment(departmentEntity);

                return RedirectToAction(nameof(DisplayDepartments));
            }
            return RedirectToAction("Login", "Account");

        
        }

        public IActionResult Edit(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (id == null)
                return BadRequest();

            var department = _departmentRepo.GetById(id);

            var departmentVM = new DepartmentVM()
            {
                DeptId = department.DeptId,
                DeptName = department.DeptName,
                DeptDesc = department.DeptDesc,
                DeptLocation = department.DeptLocation,
                DeptMgrId = department.DeptMgrId,
                MgrHireDate = department.MgrHireDate,
                Instructors = _departmentRepo.GetAllInstructors()
            };

            if (department == null)
                return NotFound();

            return View("Edit", departmentVM);
            }
            return RedirectToAction("Login", "Account");

        }


        [HttpPost]

        public IActionResult Edit(DepartmentVM departmentVM)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                _departmentRepo.UpdateDepartment(departmentVM);

                return RedirectToAction(nameof(DisplayDepartments));
            }

            departmentVM.Instructors = _departmentRepo.GetAllInstructors();
            return View(departmentVM);
            }
            return RedirectToAction("Login", "Account");


        }



        public IActionResult Delete(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                var department = _departmentRepo.GetById(id);


                if (department is not null)
                    _departmentRepo.DeleteDepartment(department);
                return RedirectToAction(nameof(DisplayDepartments));
            }

            return View();
            }
            return RedirectToAction("Login", "Account");

        }



    }
}
