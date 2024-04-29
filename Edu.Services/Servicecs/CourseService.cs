using AutoMapper;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Mappers;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace Edu.Services.Servicecs;

public class CourseService(IRepository<Course> repository, IStudentService studentService, IMapper mapper) : ICourseService
{
	public async Task<Course> AddStudentByCourseAsync(long courseId, long studentId, CancellationToken cancellation = default)
	{
        var course = await repository.SelectAsync(x => x.Id == courseId);

        if (course is null)
            throw new NullReferenceException("Null reference");

        var student = await studentService.GetStudentAsync(studentId, cancellation);

        if (student is null)
            throw new NullReferenceException("Null reference");

        var mapped = mapper.Map<Student>(student);

        if (course.Students is null)
            course.Students = new() { mapped };
        else
            course.Students = new Collection<Student>() { mapped };

        if (course.Students.Any(s => s.Id == student.Id))
            return course;

        course.Students.Add(mapped);

        await repository.UpdatedAsync(course, cancellation);
        await repository.SaveAsync();

        return course;
	}

	public async Task<ServiceResponse> CreateCourseAsync(CourseForCreateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var mapped = mapper.Map<Course>(dto);

            await repository.CreatedAsync(mapped, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return new ServiceResponse(true, "Successfully saved", mapped);
        }
        catch(Exception ex)
        {
            return new ServiceResponse(false, "Error occured while creating the Course: " + ex.Message, null);
        }
    }

    public async Task<ServiceResponse> DeleteCourseAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = await repository.SelectAsync(x => x.Id == id);

        if (course is null)
            return new ServiceResponse(false, "Course is null", null);

        await repository.DeleteAsync(course.Id, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return new ServiceResponse(true, "Successfully deleted the Course: ", course);
    }

    public async Task<CourseDto> GetCourseAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = await repository.SelectAsync(x => x.Id == id);

        if (course is null)
            throw new NullReferenceException($"No reference was found for the given Id");

        var mapped = mapper.Map<CourseDto>(course);

        return mapped;
    }

    public async Task<IEnumerable<StudentDto>> GetCourseByStudentsAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = await repository.SelectAsync(x => x.Id == id);

        if (course is null)
            throw new NullReferenceException($"No reference was found for the given Id");

        var students = course.Students;
        var mapped = mapper.Map<IEnumerable<StudentDto>>(students);

        return mapped;
    }

    public async Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken cancellationToken = default)
    {
        var courses = await repository.SelectAllAsync();

        if (courses is null)
            throw new NullReferenceException($"No reference was found for the given Id");

        var mapped = mapper.Map<IEnumerable<CourseDto>>(courses);

        return mapped;
    }

    public async Task<ServiceResponse> UpdateCourseAsync(int id, CourseForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var course = await repository.SelectAsync(x => x.Id == id);

        if (course is null)
            return new ServiceResponse(false, "Course is null", null);

        var mapped = mapper.Map<Course>(dto);
        mapped.Id = course.Id;

        var result = await repository.UpdatedAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);
        return new ServiceResponse(true, "Successfully updated Course", result);
    }
}
