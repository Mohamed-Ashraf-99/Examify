using ExaminationBLL.ModelVM.DepartmentModelVM;
using ExaminationBLL.Feature.Interface;
using ExaminationDAL.Entities;

namespace ExaminationBLL.Mapping.DepartmentMapp
{
    public class DepartmentMapper

    {
        private readonly IDepartmentRepo _departmentRepo;
        //private readonly DepartmentManager _manager;

        public DepartmentMapper()
        {

        }

        public DepartmentMapper(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        public List<DepartmentVM> DepartmentMapping(List<Department> departments)
        {
            List<DepartmentVM> departmentVMs = new List<DepartmentVM>();

            foreach (Department department in departments)
            {
                var departmentViewModel = new DepartmentVM()
                {
                    DeptId = department.DeptId,
                    DeptDesc = department.DeptDesc,
                    DeptLocation = department.DeptLocation,
                    DeptMgr = department.DeptMgr,
                    DeptMgrId = department.DeptMgrId,
                    DeptName = department.DeptName,
                    Ins = department.Ins,
                    MgrHireDate = department.MgrHireDate,
                    Students = department.Students,
                    NumberOfStudents = department.Students.Count(),
                    NumberOfInstructors = department.Ins.Count()
                };

                departmentVMs.Add(departmentViewModel);
            }


            return departmentVMs;

        }

        public DepartmentVM OneDepartmentMapping(Department department)
        {

            var departmentVM = new DepartmentVM()
            {
                DeptId = department.DeptId,
                DeptDesc = department.DeptDesc,
                DeptLocation = department.DeptLocation,
                DeptMgr = department.DeptMgr,
                DeptMgrId = department.DeptMgrId,
                DeptName = department.DeptName,
                Ins = department.Ins,
                MgrHireDate = department.MgrHireDate,
                Students = department.Students,
                NumberOfStudents = department.Students.Count(),
                NumberOfInstructors = department.Ins.Count(),

            };
            return departmentVM;
        }




    }
}
