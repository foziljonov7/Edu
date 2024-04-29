using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken cancellationToken = default);
    Task<CourseDto> GetCourseAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResponse> CreateCourseAsync(CourseForCreateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateCourseAsync(int id, CourseForUpdateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteCourseAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<StudentDto>> GetCourseByStudentsAsync(int id, CancellationToken cancellationToken = default);
    Task<Course> AddStudentByCourseAsync(long courseId, long studentId, CancellationToken cancellation = default);
}
