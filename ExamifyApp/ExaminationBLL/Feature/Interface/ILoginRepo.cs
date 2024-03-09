using ExaminationBLL.ModelVM.Authentication;
using ExaminationBLL.ModelVM.UserVM;
using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface ILoginRepo
    {
        UserVM IsValid(LoginVM loginVM); 
    }
}
