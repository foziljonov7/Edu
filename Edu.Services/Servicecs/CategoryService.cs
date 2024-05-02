using AutoMapper;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Edu.Services.Servicecs;

public class CategoryService(IRepository<Category> repository, IMapper mapper) : ICategoryService
{
    public async Task<ServiceResponse> CreateCategoryAsync(CategoryForCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<Category>(dto);

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Success", mapped);
        }
        catch(Exception ex)
        {
            return new ServiceResponse(false, "Error occured while creating the Course: " + ex.Message, null);
        }
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await repository.SelectAllAsync();

        if (categories is null)
            throw new NullReferenceException("Category is null");

        var mapped = mapper.Map<IEnumerable<CategoryDto>>(categories);
        return mapped;
    }

    public async Task<ServiceResponse> GetCategoryAsync(int id)
    {
        var category = await repository.SelectAsync(x => x.Id == id);

        if (category is null)
            return new ServiceResponse(false, "Category is null", null);

        var mapped = mapper.Map<CategoryDto>(category);
        return new ServiceResponse(true, "Success", mapped);
    }
}
