using Edu.Dtos;
using Edu.Entities;
using System.Diagnostics;

namespace Edu.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachers();
        Task<GetTeacherDto> GetTeacher(Guid id);
        Task<Teacher> CreateTeacher(CreateTeacherDto newTeacher);
        Task<Teacher> UpdateTeacher(Guid id, UpdateTeacherDto teacher);
        Task<bool> DeleteTeacher(Guid id);
    }
}
