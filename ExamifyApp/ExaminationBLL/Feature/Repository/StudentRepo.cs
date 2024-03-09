using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.StudentMapp;
using ExaminationBLL.ModelVM.StudentVM;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL.Entities;
using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationBLL.Helper;

namespace ExaminationBLL.Feature.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly StudentMap studentMap;
        public StudentRepo(ApplicationDbContext Db)
        {
            applicationDbContext = Db;
            studentMap = new StudentMap();
        }
         
        public void DeleteStudentBy(int Id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllStudentVM> getAllStudent()
        {
            var students = applicationDbContext.Students.Include(a=>a.Dept).ToList();
            foreach (var item in students)
            {
                item.St = applicationDbContext.Users.Where(user => user.UserId == item.StId).FirstOrDefault();
            }
            return studentMap.Mapp(students);
        }

        public GetStudentByIdVM GetStudentById(int? Id)
        {
            var student = applicationDbContext.Students.Where(a => a.StId == Id).Include(a => a.Dept).FirstOrDefault();
            student.St = applicationDbContext.Users.Where(user => user.UserId == student.StId).FirstOrDefault();
            student.Crs = applicationDbContext.Students
                .Where(s => s.StId == student.StId)
                .SelectMany(s => s.Crs)
                .ToList(); 
            return studentMap.Mapp(student);
        }
        public void DeleteInstructorByID(int Id)
        {
            var Deleted = applicationDbContext.Database.ExecuteSqlInterpolated($"Exec [st_deleteFromStudent] {Id}");
        }  
        public void InsertStudent(InsertStudentVM insertStudentVM) 
        {
            applicationDbContext.Database.ExecuteSql($"Exec  [st_insertIntoUsers] {insertStudentVM.UserName},{insertStudentVM.UserFname},{insertStudentVM.UserLname},{insertStudentVM.EmailAddress},{insertStudentVM.EmailAddress},{2}");
            var Data = applicationDbContext.Users.OrderByDescending(a => a.UserId).FirstOrDefault();
            applicationDbContext.Database.ExecuteSql($"Exec  [st_insertIntoStudent] {Data.UserId},{insertStudentVM.StAddress},{insertStudentVM.DeptId},{insertStudentVM.StImg}");
        }
        public void Edit(EditStudentVM editStudentVM)
        {
            if (editStudentVM.Image==null)
                editStudentVM.StImg = applicationDbContext.Students.Where(a => a.StId==editStudentVM.StId).FirstOrDefault().StImg;
            else
                editStudentVM.StImg= FileUploader.UploadFile("Imgs", editStudentVM.Image);
            applicationDbContext.Database.ExecuteSql($"Exec [st_updateStudent]{editStudentVM.StId}, {editStudentVM.StAddress},{editStudentVM.DeptId},{editStudentVM.StImg}");
            applicationDbContext.Database.ExecuteSql($"Exec [st_updateUsers] {editStudentVM.StId} ,{editStudentVM.UserFname},{editStudentVM.UserLname},{editStudentVM.EmailAddress},{editStudentVM.Password}");
        }

        public EditStudentVM GetStudentDataById(int Id) 
        {
            var student = applicationDbContext.Users.Where(a => a.UserId == Id).Include(a => a.Student).ThenInclude(a=>a.Dept).FirstOrDefault();
            return new EditStudentVM() { EmailAddress = student.EmailAddress, UserFname = student.UserFname, UserLname = student.UserLname, Password = student.Password, StId = student.UserId, StImg = student.Student.StImg, StAddress = student.Student.StAddress, DeptId =student.Student.DeptId };
        }

      

  
    }
}
