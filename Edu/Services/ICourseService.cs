using Edu.Dtos;
using Edu.Entities;

namespace Edu.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses();
        Task<GetCourseDto> GetCourse(Guid id);
        Task<Course> CreateCourse(CreateCourseDto newCourse);
        Task<Course> UpdateCourse(Guid id, UpdateCourseDto course);
        Task<bool> DeleteCourse(Guid id);
    }
}
