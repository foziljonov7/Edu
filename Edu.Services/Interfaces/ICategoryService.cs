using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    Task<ServiceResponse> GetCategoryAsync(int id);
    Task<ServiceResponse> CreateCategoryAsync(CategoryForCreateDto dto, CancellationToken cancellationToken = default);
    Task<IEnumerable<SubjectDto>> GetCategoryBySubjectAsync(int id, CancellationToken cancellationToken = default);
} 
    