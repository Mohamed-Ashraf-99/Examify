using ExaminationBLL.ModelVM.DepartmentModelVM;
using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL.Entities;

namespace ExaminationBLL.Feature.Interface
{
    public interface IDepartmentRepo
    {
        List<DepartmentVM> GetAllDepartments();
        DepartmentVM GetById(int id);
        int GetCountOfStudents(int departmentId);

        void AddDepartment(Department department);

       List<Instructor> GetAllInstructors();

       int GetCountOfInstructors(Department department);

        void UpdateDepartment(DepartmentVM department);

        void DeleteDepartment(DepartmentVM department);
    }
}
