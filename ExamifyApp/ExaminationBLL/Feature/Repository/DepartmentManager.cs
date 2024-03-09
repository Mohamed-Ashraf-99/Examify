using ExaminationDAL.Entities;
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.DepartmentMapp;
using ExaminationBLL.ModelVM.DepartmentModelVM;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ExaminationBLL.Feature.Repository
{
    public class DepartmentManager : IDepartmentRepo
    {
        ApplicationDbContext _context;
        DepartmentMapper _Mapper = new DepartmentMapper();
        public DepartmentManager(ApplicationDbContext context)
        {
            _context = context;

        }

        public void AddDepartment(Department department)
        {
            //_context.Departments.Add(department);

            _context.Database.ExecuteSql($"Exec [st_insertIntoDepartment] {department.DeptName}, {department.DeptDesc}, {department.DeptLocation}, {department.DeptMgrId}, {department.MgrHireDate}");
            _context.SaveChanges();
        }


        public List<DepartmentVM> GetAllDepartments()
        {
            var departmentList = _context.Departments.Include(b => b.Students).Include(d => d.Ins).ToList();

            var departments = _Mapper.DepartmentMapping(departmentList);
            return departments;
        }

        public DepartmentVM GetById(int id)
        {
            var department = _context.Departments.Include(b => b.Students).Include(d => d.Ins).Where(d => d.DeptId == id).FirstOrDefault();

            var departmentVM = _Mapper.OneDepartmentMapping(department);

            return departmentVM;
        }


        public int GetCountOfStudents(int departmentId)
        {
            var studentCount = _context.Students
                .Where(s => s.DeptId == departmentId)
                .Count();

            return studentCount;
        }

        public List<Instructor> GetAllInstructors()
        {
            var instructors = _context.Instructors.Include(i => i.Ins).OrderBy(m => m.Ins.UserName).ToList();

            return instructors;
        }

        public int GetCountOfInstructors(Department department)
        {

            var numberOfInstructors = _context.Database.ExecuteSql($"Exec [GetInstructorCountByDepartmentId] {department.DeptId}");



            return numberOfInstructors;
        }

        public void UpdateDepartment(DepartmentVM department)
        {
            _context.Database.ExecuteSql($"Exec [st_updateDepartment] {department.DeptId}, {department.DeptName}, {department.DeptDesc}, {department.DeptLocation}, {department.DeptMgrId}, {department.MgrHireDate}");
            //_context.SaveChanges();
        }

        public void DeleteDepartment(DepartmentVM department)
        {
            _context.Database.ExecuteSql($"Exec [st_deleteFromDepartment] {department.DeptId}");
            _context.SaveChanges();
        }

    }
}
