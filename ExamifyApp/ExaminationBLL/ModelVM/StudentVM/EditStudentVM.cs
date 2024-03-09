using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.StudentVM
{
    public class EditStudentVM
    {
        [Key]
        public int StId { get; set; }

        public string? StAddress { get; set; }

        public int? DeptId { get; set; }

        [Required, MaxLength(15)]

        public string UserFname { get; set; }
        [Required, MaxLength(15)]

        public string UserLname { get; set; }
        [Required, EmailAddress]

        public string EmailAddress { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public string? StImg { get; set; }
        public IFormFile? Image { get; set; }
    }
}
