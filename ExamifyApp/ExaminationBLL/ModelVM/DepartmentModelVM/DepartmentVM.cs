using System.ComponentModel.DataAnnotations;
using ExaminationDAL.Entities;

namespace ExaminationBLL.ModelVM.DepartmentModelVM
{
    public class DepartmentVM
    {
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Department Name must be between 2 and 50 characters")]
        public string? DeptName { get; set; }

        [Required(ErrorMessage = "Department Description is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Department Description must be between 2 and 100 characters")]
        public string? DeptDesc { get; set; }

        [Required(ErrorMessage = "Department Location is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Department Location must be between 2 and 100 characters")]
        public string? DeptLocation { get; set; }

        [Required(ErrorMessage = "Manager is required")]
        public int? DeptMgrId { get; set; }

        [Required(ErrorMessage = "Manager Hire Date is required")]
        [DataType(DataType.Date)]
        public DateOnly? MgrHireDate { get; set; }

        public virtual Instructor? DeptMgr { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<Instructor> Ins { get; set; } = new List<Instructor>();

        public IEnumerable<Instructor>? Instructors { get; set; }

        public int NumberOfStudents { get; set; }
        public int NumberOfInstructors { get; set; }
    }
}