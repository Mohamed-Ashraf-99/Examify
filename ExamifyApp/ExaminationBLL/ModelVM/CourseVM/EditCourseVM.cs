using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.CourseVM
{
    public class EditCourseVM
    {
        public int CrsId { get; set; }
        [Required,MinLength(1,ErrorMessage ="Min Length is 1 ")]
        public string CrsName { get; set; }
        [Required]
        public int CrsDuration { get; set; }
    }
}
//Data Anotation