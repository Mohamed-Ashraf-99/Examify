using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.GenerateVM.Validation
{
    public class CheckDecimal : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? obj, ValidationContext validationContext)
        {
            if (obj != null && int.TryParse(obj.ToString(), out _))
            {
                return ValidationResult.Success; 
            }

            return new ValidationResult("The field must not be a valid decimal.");
        }
    }
   
}
