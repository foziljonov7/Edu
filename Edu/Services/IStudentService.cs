using Edu.Dtos;
using Edu.Entities;

namespace Edu.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<GetStudentDto> GetStudent(Guid id);
        Task<Student> CreateStudent(CreateStudentDto newStudent);
        Task<Student> UpdateStudent(Guid id, UpdateStudentDto student);
        Task<bool> DeleteStudent(Guid id);
    }
}
