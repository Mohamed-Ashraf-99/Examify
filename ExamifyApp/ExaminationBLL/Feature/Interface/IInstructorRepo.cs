using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationDAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface IInstructorRepo
    {
        List<GetAllInstructorVM> getAllInstructor();
        
        void DeleteInstructorByID(int Id);
        void InsertInstructor(InsertInstructorVM instructorVM);
        void Edit(EditInstractorVM editInstractorVM);
        GetInstructorByIdVM GetInstructorById(int id);
        EditInstractorVM GetInstructorDataById(int id);
    }
}
