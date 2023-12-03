using DL.DbModels;
using MyWebApiStudentGPA.Interfaces;

namespace MyWebApiStudentGPA.Implementations
{
    public class StudentClass : IStudentClass
    {
        private readonly StudentDbContext _context;

        public StudentClass(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateStudent(StudentDbDto student)
        {
            try
            {
                _context.studentDbDto.Add(student);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return "Student created successfully";
                else
                    return "Failed to create student";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateStudent(int id, StudentDbDto student)
        {
            try
            {
                var existingStudent = await _context.studentDbDto.FindAsync(id);

                if (existingStudent == null)
                {
                    return null;
                }

                existingStudent.Name = student.Name;
                existingStudent.RollNumber = student.RollNumber;
                existingStudent.PhoneNumber = student.PhoneNumber;

                var saved = await _context.SaveChangesAsync();
                if (saved > 0)
                    return "Student updated successfully";
                else
                    return "Failed to update student";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.studentDbDto.FindAsync(id);

                if (student == null)
                {
                    return null;
                }

                _context.studentDbDto.Remove(student);
                var saved = await _context.SaveChangesAsync();
                if (saved > 0)
                    return "student deleted successfully";
                else
                    return "Failed to delete student";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentDbDto> GetStudentById(int id)
        {
            try
            {
                var student = await _context.studentDbDto.FindAsync(id);

                if (student == null)
                    return null;
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StudentDbDto>> GetAllStudents()
        {
            try
            {
                var students = _context.studentDbDto.ToList();
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
