using ExaminationDAL.Entities;

namespace ExaminationBLL.ModelVM.CourseVM
{
    public class InsertCourseVM
    {
        public int CrsId { get; set; }

        public string? CrsName { get; set; }

        public int? CrsDuration { get; set; }

        public List<Topic>? Topics { get; set; }
    }
}