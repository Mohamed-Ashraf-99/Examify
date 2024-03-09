using ExaminationDAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.StudentVM
{
    public class InsertStudentVM
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "User FName is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserFname { get; set; }
        [Required(ErrorMessage = "User LName is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string UserLname { get; set; }

        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is Required"), MinLength(3, ErrorMessage = "Min Length 3")]

        public string Password { get; set; }

        public string? StAddress { get; set; }

        public int? DeptId { get; set; }

        public string? StImg { get; set; }

        public IFormFile? Image { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
