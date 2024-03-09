using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.ModelVM.GenerateVM
{
    public class StudentGenerateExamVM
    {
        [Key]
        public int StID { get; set; }
      
        public string StName { get; set; }
        public bool IsSelected { get; set; }
        
    }
}
