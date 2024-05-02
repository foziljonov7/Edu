using AutoMapper;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Domain.Models;
using Edu.Services.Helpers.Mappers;
using Edu.Services.Helpers.Responses;
using Edu.Services.Interfaces;

namespace Edu.Services.Servicecs;

public class CourseService(
    IRepository<Course> repository,
    IMapper mapper,
    IRepository<Student> studentRepository) : ICourseService
{
	public async Task<ServiceResponse> AddStudentAsync(long courseId, long studentId, CancellationToken cancellation = default)
	{
		var existingRelation = await repository.SelectAsync(x => x.Id == courseId && x.Students.Any(s => s.Id == studentId));
		if (existingRelation != null)
		{
			return new ServiceResponse(false, "The student is already enrolled in the course", null);
		}

		var student = await studentRepository.SelectAsync(x => x.Id == studentId);
		var course = await repository.SelectAsync(x => x.Id == courseId);

		course.Students.Add(student);
		student.Courses.Add(course);

		await studentRepository.UpdatedAsync(student);
		await studentRepository.SaveAsync(cancellation);
		await repository.UpdatedAsync(course);
		await repository.SaveAsync(cancellation);

		var mapped = mapper.Map<CourseDto>(course);

		return new ServiceResponse(true, "Success", mapped);
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
        var course = await repository.ExistAsync(id);

        if (!course)
            return new ServiceResponse(false, "Course is null", null);

        await repository.DeleteAsync(id, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return new ServiceResponse(true, "Successfully deleted the Course: ", course);
    }

    public async Task<ServiceResponse> GetCourseAsync(int id, CancellationToken cancellationToken = default)
    {
		var includes = new string[] { "Students" };
		var course = await repository.SelectAsync(x => x.Id == id, includes);

        if (course is null)
            return new ServiceResponse(false, "Course is null", null);

        var mapped = mapper.Map<CourseDto>(course);

        return new ServiceResponse(true, "Success", mapped);
    }

    public async Task<IEnumerable<CourseDto>> GetCourseByStudentsAsync(int id, CancellationToken cancellationToken = default)
    {
        var course = await repository.SelectAllAsync(x => x.Students.Any(s => s.Id == id));

        if (course is null)
            throw new NullReferenceException($"No reference was found for the given Id");

        var students = course;
        var mapped = mapper.Map<IEnumerable<CourseDto>>(students);

        return mapped;
    }

    public async Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken cancellationToken = default)
    {
        var includes = new string[]{ "Students", "Teacher" };

		var courses = await repository.SelectAllAsync(includes: includes);

		if (courses is null)
            throw new NullReferenceException($"No reference was found for the given Id");

        var mapped = mapper.Map<IEnumerable<CourseDto>>(courses);

        return mapped;
    }

    public async Task<ServiceResponse> UpdateCourseAsync(int id, CourseForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        if (!await repository.ExistAsync(id, cancellationToken))
            return new ServiceResponse(false, "Course is null", null);

        var mapped = mapper.Map<Course>(dto);
        mapped.Id = id;

        var result = await repository.UpdatedAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);
        return new ServiceResponse(true, "Successfully updated Course", result);
    }
}
