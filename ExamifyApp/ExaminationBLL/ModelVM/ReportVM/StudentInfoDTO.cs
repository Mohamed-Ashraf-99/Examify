using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationDAL.ModelVM.ReportVM
{
    public record StudentInfoDTO(int St_id, string UserName, string EmailAddress, string UserFname, string UserLname, string Address)
    {

    }
}
