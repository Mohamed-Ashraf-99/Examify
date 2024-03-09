using ExaminationBLL.Feature.Interface;

using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationBLL.Mapping.InstructorMapp;
using ExaminationDAL.Entities;
using ExaminationBLL.ModelVM.InstructorVM;

namespace ExaminationBLL.Feature.Repository
{
    public class InstructorRepo:IInstructorRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly InstructorMapp instructorMapp;

        public InstructorRepo(ApplicationDbContext Db)
        {
            applicationDbContext = Db;
            instructorMapp = new InstructorMapp();
        }

        public List<GetAllInstructorVM> getAllInstructor()
        {
            var instructor = applicationDbContext.Instructors.Include(a => a.Ins).ToList();
            return instructorMapp.Mapp(instructor);
        }

        public GetInstructorByIdVM GetInstructorById(int Id)
        {
            var instructor =applicationDbContext.Instructors.Where(a=>a.InsId == Id).Include(a => a.Departments).FirstOrDefault();
            instructor.Ins = applicationDbContext.Users.Where(user => user.UserId == instructor.InsId).FirstOrDefault();
            return instructorMapp.Mapp(instructor);
        }
        public void DeleteInstructorByID(int Id)
        {
            var Deleted = applicationDbContext.Database.ExecuteSqlInterpolated($"Exec [st_deleteFromInstructor] {Id}");
        }

        public void InsertInstructor(InsertInstructorVM instructorVM)
        {
            applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoUsers] {instructorVM.UserName},{instructorVM.UserFname},{instructorVM.UserLname},{instructorVM.EmailAddress},{instructorVM.EmailAddress},{1}");
            var Data = applicationDbContext.Users.OrderByDescending(a=>a.UserId).FirstOrDefault();
            applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoInstructor] {Data.UserId},{instructorVM.InsDegree}, {instructorVM.InsSalary}");
        }

        public void Edit(EditInstractorVM editInstractorVM)
        {
            
            applicationDbContext.Database.ExecuteSql($"Exec [st_updateInstructor] {editInstractorVM.InsId},{editInstractorVM.InsDegree},{editInstractorVM.InsSalary}");
            applicationDbContext.Database.ExecuteSql($"Exec [st_updateUsers] {editInstractorVM.InsId} ,{editInstractorVM.UserFname},{editInstractorVM.UserLname},{editInstractorVM.Email},{editInstractorVM.Password}");
        }

        public EditInstractorVM GetInstructorDataById(int id)
        {
            var instructor = applicationDbContext.Users.Where(a => a.UserId == id).Include(a => a.Instructor).FirstOrDefault();
            return new EditInstractorVM() { Email = instructor.EmailAddress, InsDegree = instructor.Instructor.InsDegree, Password = instructor.Password, UserFname = instructor.UserFname, UserLname = instructor.UserLname, InsId = instructor.UserId, InsSalary = (int) instructor.Instructor.InsSalary };
        }
    }
}
