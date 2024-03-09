using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Feature.Repository;
using ExaminationDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExaminationPL.Controllers.Admin
{
    public class ReportController : Controller
    {
        private readonly IDepartmentRepo Department;
        private readonly IReportRepo Report;
        private readonly IStudentRepo studentRepo;
        private readonly IExamRepo examRepo;
        private readonly IExamRepository _examRepository;
        private readonly ICourseRepo _courseRepo;

        public IInstructorRepo InstructorRepo;

        public ReportController(IStudentRepo studentRepo, ICourseRepo _courseRepo, IExamRepo examRepo,IReportRepo report, IDepartmentRepo Department, IExamRepository examRepository,IInstructorRepo instructorRepo)
        {
            this.Department = Department;
            Report=report;
            this._examRepository= examRepository;
            InstructorRepo=instructorRepo;
            this.studentRepo=studentRepo;
            this.examRepo=examRepo;
            this._courseRepo= _courseRepo;
        }
        public IActionResult Index()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int ? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                ViewBag.AllDepartment = Department.GetAllDepartments();
                ViewBag.AllExam = examRepo.GetAllExam();
                ViewBag.AllInstractor = InstructorRepo.getAllInstructor();
                ViewBag.AllStudent = studentRepo.getAllStudent();
                ViewBag.AllCourse =_courseRepo.GetAll();
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult StudentInformation(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var  Data = Report.GetStudentByDepartmentId(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult ExamQuestions(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var Data = _examRepository.GetExamById(id);
            return View(Data);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult StudentCourses(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = Report.st_getInstructorCoursesAndStudentsPerCourse(id);
            return View(data);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult StudentGrade(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = Report.st_getStudentGradesInAllCourses(id);
            return View(data);
            }
            return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public IActionResult CourseTopic(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = Report.st_getTopicsByCourseID(id);
            return View(data);
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public IActionResult ExamStudentAnswerCiew(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = Report.GetAllExamStudent(id);
            return View(data);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult ExamStudentAnswer(int id, int stid )
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            int? RoleID = HttpContext.Session.GetInt32("RoleId");
            if (UserId != null && RoleID==1)
            {
                var data = Report.st_showExamWithStudentAnswers(id, stid);
            return View(data);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
