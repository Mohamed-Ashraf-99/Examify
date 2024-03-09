using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.InstructorVM
{
    public class GetInstructorByIdVM
    {
        public int InsId { get; set; }

        public string? UserName { get; set; }

        public string? UserFname { get; set; }

        public string? UserLname { get; set; }
        public string? InsDegree { get; set; }

        public decimal? InsSalary { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
