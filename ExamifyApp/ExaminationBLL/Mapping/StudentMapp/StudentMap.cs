using ExaminationBLL.ModelVM.StudentVM;
using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Mapping.StudentMapp
{
    public class StudentMap
    {
        public List<GetAllStudentVM> Mapp(List<Student> students)
        {
            List<GetAllStudentVM> getAllStudentVMs = new List<GetAllStudentVM>();
            foreach (Student student in students)
            {
                getAllStudentVMs.Add(new GetAllStudentVM { StId = student.StId, UserLname = student.St.UserLname, UserFname = student.St.UserFname, StAddress = student.StAddress, StImg = student.StImg, Dept = student.Dept, UserName = student.St.UserName });
            }
            return getAllStudentVMs;
        }
        public GetStudentByIdVM Mapp(Student student)
        {
            GetStudentByIdVM getStudentByIdVM = new GetStudentByIdVM() { courses = student.Crs, Email = student.St.EmailAddress, UserLname = student.St.UserLname, UserFname = student.St.UserFname, StAddress = student.StAddress, StImg = student.StImg, Dept = student.Dept, UserName = student.St.UserName };
            return getStudentByIdVM;
        }

        public InsertStudentVM Map(InsertStudentVM insertStudentVM)
        {
            InsertStudentVM insertStudent = new InsertStudentVM() { UserName = insertStudentVM.UserName, UserFname = insertStudentVM.UserFname, UserLname = insertStudentVM.UserLname, EmailAddress = insertStudentVM.EmailAddress, Password = insertStudentVM.Password, DeptId = insertStudentVM.DeptId, StAddress = insertStudentVM.StAddress };
            return insertStudent;
        }
    }
}
