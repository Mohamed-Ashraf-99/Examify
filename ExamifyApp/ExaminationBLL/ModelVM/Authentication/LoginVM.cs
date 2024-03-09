using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.Authentication
{
    public class LoginVM
    {
      

        [Required(ErrorMessage = "User name Required")]
        [MaxLength(100, ErrorMessage = "MaxLength 100")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Min Length 6")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
