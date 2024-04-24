using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<TeacherDto>> GetTeachersAsync(CancellationToken cancellationToken = default);
    Task<TeacherDto> GetTeacherAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResponse> CreateTeacherAsync(TeacherForCreateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateTeacherAsync(int id, TeacherForUpdateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteTeacherAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CourseDto>> GetTeacherByCoursesAsync(int id, CancellationToken cancellationToken = default);
    Task<TeacherDto> GetStudentByNameAsync(string name, CancellationToken cancellationToken = default);
}
