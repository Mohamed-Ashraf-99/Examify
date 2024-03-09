using ExaminationBLL.ModelVM.InstructorVM;
using ExaminationBLL.ModelVM.StudentVM;


namespace ExaminationBLL.Feature.Interface
{
   public interface IStudentRepo
    {
        List<GetAllStudentVM>getAllStudent();
        
        void DeleteInstructorByID(int Id);

        void InsertStudent(InsertStudentVM insertStudentVM);
        void Edit(EditStudentVM editStudentVM);
        GetStudentByIdVM GetStudentById(int? Id);
        EditStudentVM GetStudentDataById(int id);
    }
}
