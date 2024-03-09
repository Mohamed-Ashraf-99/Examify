using ExaminationDAL.Entities;

namespace ExaminationBLL.ModelVM.StudentPreExamVM
{
    public class StudentPreExamVM
    {
        public int StId { get; set; }

        public string? StAddress { get; set; }

        public int? DeptId { get; set; }

        public string? StImg { get; set; }


        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

        public virtual User St { get; set; } = null!;

        public virtual ICollection<Course> Crs { get; set; } = new List<Course>();
    }
}