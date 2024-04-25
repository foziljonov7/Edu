using AutoMapper;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;
using System.Xml.Schema;

namespace Edu.Services.Servicecs;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> repository;
    private readonly IMapper mapper;

    public StudentService(
        IRepository<Student> repository,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<ServiceResponse> CreateStudentAsync(StudentForCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<Student>(dto);

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Successfully created Student", mapped);
        }
        catch(Exception ex)
        {
            return new ServiceResponse(false, "Error occured while creating the Student: " + ex.Message, null);
        }
    }

    public async Task<ServiceResponse> DeleteStudentAsync(int id, CancellationToken cancellationToken = default)
    {
        var student = await repository.SelectAsync(x => x.Id == id);

        if (student is null)
            return new ServiceResponse(false, "Student is null", null);

        await repository.DeleteAsync(student.Id, cancellationToken);
        return new ServiceResponse(true, "Successfully deleted Student", student);
    }

    public async Task<StudentDto> GetStudentAsync(int id, CancellationToken cancellationToken = default)
    {
        var student = await repository.SelectAsync(x => x.Id == id);

        if (student is null)
            throw new NullReferenceException("Null reference");

        var mapped = mapper.Map<StudentDto>(student);

        return mapped;
    }

    public async Task<IEnumerable<StudentDto>> GetStudentsAsync(CancellationToken cancellationToken = default)
    {
        var students = await repository.SelectAllAsync();

        if (students is null)
            throw new NullReferenceException("Null reference");

        var mapped = mapper.Map<IEnumerable<StudentDto>>(students);

        return mapped;
    }

    public async Task<ServiceResponse> UpdateStudentAsync(int id, StudentForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var student = await repository.SelectAsync(x => x.Id == id);

        if (student is null)
            return new ServiceResponse(false, "Student is null", null);

        var mapped = mapper.Map<Student>(dto);
        mapped.Id = student.Id;

        var result = await repository.UpdatedAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return new ServiceResponse(true, "Successfully updated Student ", result);
    }
}
