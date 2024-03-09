using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Feature.Repository;
using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationBLL.ModelVM.InstructorVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Diagnostics.CodeAnalysis;
using ExaminationBLL.Feature.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ExaminationBLL.Helper;

namespace ExaminationPL.Controllers.Admin
{
    public class InstructorController : Controller
    {

        //tranisient
        //Scope
        //SingleTone
        private readonly IInstructorRepo instructorRepo;
        public InstructorController(IInstructorRepo _instructorRepo)
        {
           this. instructorRepo = _instructorRepo;
        }
        public IActionResult getAll()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = instructorRepo.getAllInstructor();
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        public IActionResult GetInstructorById(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = instructorRepo.GetInstructorById(id);
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
                instructorRepo.DeleteInstructorByID(Id);
            return RedirectToAction("getAll");
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public IActionResult InsertInstructor()
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
        public IActionResult InsertInstructor(InsertInstructorVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {


                instructorRepo.InsertInstructor(model);
                return RedirectToAction("getAll");
            }
            return View(model);
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
                if (id == null)
                return NotFound();
            
            var Data = instructorRepo.GetInstructorDataById(id);
            if (Data==null)
                return NotFound();
            return View(Data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult Edit(EditInstractorVM model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                if (ModelState.IsValid)
            {
                instructorRepo.Edit(model);
                return RedirectToAction("getAll");
            }
            return View(model);
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
