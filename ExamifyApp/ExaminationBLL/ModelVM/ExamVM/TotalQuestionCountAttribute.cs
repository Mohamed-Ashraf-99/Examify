using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using ExaminationBLL.ModelVM.GenerateVM;

namespace ExaminationBLL.ModelVM.ExamVM
{
    public class TotalQuestionCountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = validationContext.ObjectInstance as GenerateExam;

            if (viewModel != null)
            {
                if (viewModel.trueOrFalseCounnt != null && viewModel.otherQuestionCount != null)
                {
                    int trueOrFalseCount;
                    int otherQuestionCount;

                    if (int.TryParse(viewModel.trueOrFalseCounnt, out trueOrFalseCount) && int.TryParse(viewModel.otherQuestionCount, out otherQuestionCount))
                    {
                        if (trueOrFalseCount + otherQuestionCount == 10)
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
            }

            return new ValidationResult("The total count of questions must be 10.");
        }
    }
}
