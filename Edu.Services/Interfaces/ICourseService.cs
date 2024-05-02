using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken cancellationToken = default);
    Task<ServiceResponse> GetCourseAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResponse> AddStudentAsync(long courseId, long studentId, CancellationToken cancellation = default);
    Task<ServiceResponse> CreateCourseAsync(CourseForCreateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateCourseAsync(int id, CourseForUpdateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteCourseAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CourseDto>> GetCourseByStudentsAsync(int id, CancellationToken cancellationToken = default);
}
