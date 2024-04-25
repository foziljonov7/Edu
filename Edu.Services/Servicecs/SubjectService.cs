using AutoMapper;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class SubjectService(IRepository<Subject> repository, IMapper mapper) : ISubjectService
{
    public async Task<ServiceResponse> CreateSubjectAsync(SubjectForCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<Subject>(dto);

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Successfully created Subject", mapped);
        }
        catch(Exception ex)
        {
            return new ServiceResponse(false, "Error occured while creating the Subject: " + ex.Message, null);
        }
    }

    public Task<SubjectDto> GetSubjectAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetSubjectByCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SubjectDto>> GetSubjectsAsync(CancellationToken cancellationToken = default)
    {
        var subjects = await repository.SelectAllAsync();

        if (subjects is null)
            throw new NullReferenceException("Subjects is null");

        var mapped = mapper.Map<IEnumerable<SubjectDto>>(subjects);
        return mapped;
    }

    public Task<ServiceResponse> UpdateSubjectAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
