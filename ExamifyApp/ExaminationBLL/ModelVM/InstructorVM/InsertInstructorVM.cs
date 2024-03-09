using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.InstructorVM
{
    public class InsertInstructorVM
    {
       

        public int? UserId { get; set; }
        [Required(ErrorMessage = "User Name is Required"), MinLength(3, ErrorMessage = "Min Length 3")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Fname is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserFname { get; set; }
        [Required(ErrorMessage = "User Lname is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserLname { get; set; }
        [Required(ErrorMessage = "Email Address is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string Password { get; set; }
      
        public string? InsDegree { get; set; }

        public decimal? InsSalary { get; set; }
    }
}
