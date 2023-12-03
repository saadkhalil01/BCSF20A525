using DL.DbModels;

namespace MyWebApiStudentGPA.Interfaces
{
    public interface IStudentClass
    {
        Task<string> CreateStudent(StudentDbDto student);
        Task<string> UpdateStudent(int id, StudentDbDto student);
        Task<string> DeleteStudent(int id);
        Task<StudentDbDto> GetStudentById(int id);
        Task<List<StudentDbDto>> GetAllStudents();
    }
}
