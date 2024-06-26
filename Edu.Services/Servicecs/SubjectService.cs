﻿using AutoMapper;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class SubjectService(IRepository<Subject> repository, IMapper mapper) : ISubjectService
{
    private readonly string[] includes = new string[] { "Category" };
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

    public async Task<ServiceResponse> GetSubjectAsync(int id, CancellationToken cancellationToken = default)
    {
        var subject = await repository.SelectAsync(x => x.Id == id, includes);

        if (subject is null)
            return new ServiceResponse(false, "Subject is null", null);

        var mapped = mapper.Map<SubjectDto>(subject);
        return new ServiceResponse(true, "Success", mapped);
    }

    public async Task<CategoryDto> GetSubjectByCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        var subjectCategory = await repository.SelectAsync(x => x.Id == id);

        if (subjectCategory is null)
            throw new NullReferenceException("Subject is null");

        var mapped = mapper.Map<CategoryDto>(subjectCategory);
        return mapped;
    }

    public async Task<IEnumerable<SubjectDto>> GetSubjectsAsync(CancellationToken cancellationToken = default)
    {
        var subjects = await repository.SelectAllAsync(includes: includes);

        if (subjects is null)
            throw new NullReferenceException("Subjects is null");

        var mapped = mapper.Map<IEnumerable<SubjectDto>>(subjects);
        return mapped;
    }

    public async Task<ServiceResponse> UpdateSubjectAsync(int id, SubjectForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        if (!await repository.ExistAsync(id, cancellationToken))
            return new ServiceResponse(false, "Subject is null", null);

        var mapped = mapper.Map<Subject>(dto);
        mapped.Id = id;
        await repository.UpdatedAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);
        return new ServiceResponse(true, "Success", mapped);
    }
}
