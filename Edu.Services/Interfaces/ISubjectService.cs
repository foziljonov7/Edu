using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface ISubjectService
{
    Task<IEnumerable<SubjectDto>> GetSubjectsAsync(CancellationToken cancellationToken = default);
    Task<ServiceResponse> GetSubjectAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResponse> CreateSubjectAsync(SubjectForCreateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateSubjectAsync(int id, SubjectForUpdateDto dto, CancellationToken cancellationToken = default);
    Task<CategoryDto> GetSubjectByCategoryAsync(int id, CancellationToken cancellationToken = default);
}
