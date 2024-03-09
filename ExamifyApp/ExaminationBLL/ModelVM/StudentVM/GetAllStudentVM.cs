using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.StudentVM
{
    public class GetAllStudentVM
    {
        public int StId { get; set; }
        public string? UserName { get; set; }

        public string? UserFname { get; set; }

        public string? UserLname { get; set; }

        public string? StAddress { get; set; }
        public string? StImg { get; set; }
        public virtual Department? Dept { get; set; }

    }
}
