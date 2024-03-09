using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.CourseVM
{
    public class GetAllCoursesVM
    {
        public int CrsId { get; set; }

        public string? CrsName { get; set; }

        public int? CrsDuration { get; set; }

        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public virtual ICollection<Instructor> Ins { get; set; } = new List<Instructor>();

    }
}
