using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Mapping.InstructorMapp
{
    public class InstructorMapp
    {
        public List<GetAllInstructorVM> Mapp(List <Instructor>instructors)
        {
            List<GetAllInstructorVM>getAllInstructors = new List<GetAllInstructorVM>();
            foreach (Instructor instructor in instructors)
            {
                getAllInstructors.Add(new GetAllInstructorVM { InsId = instructor.InsId, UserName = instructor.Ins.UserName, UserFname = instructor.Ins.UserFname, InsDegree = instructor.InsDegree, UserLname = instructor.Ins.UserLname, InsSalary = instructor.InsSalary });
            }
            return getAllInstructors;
        }

        public GetInstructorByIdVM Mapp (Instructor instructor)
        {
            GetInstructorByIdVM getInstructorById = new GetInstructorByIdVM() { InsId = instructor.InsId, UserName = instructor.Ins.UserName, UserFname = instructor.Ins.UserFname, InsDegree = instructor.InsDegree, UserLname = instructor.Ins.UserLname, InsSalary = instructor.InsSalary, Departments=instructor.Departments};
            return getInstructorById;
        }
        public InsertInstructorVM Map (InsertInstructorVM insertInstructorVM)
        {
            InsertInstructorVM insertInstructor = new InsertInstructorVM() { UserName = insertInstructorVM.UserName, UserFname = insertInstructorVM.UserFname,UserLname=insertInstructorVM.UserLname,EmailAddress=insertInstructorVM.EmailAddress,Password=insertInstructorVM.Password,InsDegree = insertInstructorVM.InsDegree, InsSalary = insertInstructorVM.InsSalary };
            return insertInstructor;
        }
     
    }
}
