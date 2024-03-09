using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.InstructorVM
{
    public class EditInstractorVM
    {
        public int InsId { get; set; }
        [Required]
        public string InsDegree { get; set; }
        [Required(ErrorMessage = "Degree is Required")]

        public decimal InsSalary { get; set; }
        [Required(ErrorMessage = "UserFname is Required"),MinLength(2 ,ErrorMessage ="Min Length 2")]

        public string UserFname { get; set; }
        [Required(ErrorMessage = "UserLname is Required"), MinLength(2, ErrorMessage = "Min Length 2")]

        public string UserLname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Password { get; set; }

    }
}
