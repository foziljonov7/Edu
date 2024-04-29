using AutoMapper;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Responses;
using Edu.Services.Helpers.Mappers;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class TeacherService(IRepository<Teacher> repository, IMapper mapper) : ITeacherService
{
    public async Task<ServiceResponse> CreateTeacherAsync(TeacherForCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<Teacher>(dto);

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Successfully saved Teacher", mapped);
        }
        catch (Exception ex)
        {
            return new ServiceResponse(false, "Error occured while creating the Course: " + ex.Message, null);
        }
    }

    public async Task<ServiceResponse> DeleteTeacherAsync(int id, CancellationToken cancellationToken = default)
    {
        var teacher = await repository.SelectAsync(x => x.Id == id);

        if (teacher is null)
            return new ServiceResponse(false, "Teacher is null", null);

        await repository.DeleteAsync(teacher.Id, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return new ServiceResponse(true, "Successfully deleted Teacher", teacher);
    }

    public async Task<TeacherDto> GetStudentByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var teacher = await repository.SelectAsync(x => x.FirstName == name);

        if (teacher is null)
            throw new NullReferenceException("No reference was found for the given Firstname");

        var mapped = mapper.Map<TeacherDto>(teacher);

        return mapped;
    }

    public async Task<TeacherDto> GetTeacherAsync(int id, CancellationToken cancellationToken = default)
    {
        var teacher = await repository.SelectAsync(x => x.Id == id);

        if (teacher is null)
            throw new NullReferenceException("No reference was found for the given Id");

        var mapped = mapper.Map<TeacherDto>(teacher);
        return mapped;
    }

    public async Task<IEnumerable<CourseDto>> GetTeacherByCoursesAsync(int id, CancellationToken cancellationToken = default)
    {
        var teacherCourses = await repository.SelectAsync(x => x.Id == id);

        if (teacherCourses is null)
            throw new NullReferenceException("No reference was found for the given Id");

        var courses = teacherCourses.Courses;
        var mapped = mapper.Map<IEnumerable<CourseDto>>(courses);

        return mapped;
    }

    public async Task<IEnumerable<TeacherDto>> GetTeachersAsync(CancellationToken cancellationToken = default)
    {
        var teachers = await repository.SelectAllAsync();

        if (teachers is null)
            throw new NullReferenceException("Teachers is null");

        var mapped = mapper.Map<IEnumerable<TeacherDto>>(teachers);
        return mapped;
    }

    public async Task<ServiceResponse> UpdateTeacherAsync(int id, TeacherForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var teacher = await repository.SelectAsync(x => x.Id == id);

        if (teacher is null)
            return new ServiceResponse(false, "Teacher is null", null);

        var mapped = mapper.Map<Teacher>(dto);
        mapped.Id = teacher.Id;

        var result = await repository.UpdatedAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return new ServiceResponse(true, "Successfully updated Teacher", result);
    }
}
