﻿using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.Services.Helpers.Responses;

namespace Edu.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetStudentsAsync(CancellationToken cancellationToken = default);
    Task<ServiceResponse> GetStudentAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResponse> CreateStudentAsync(StudentForCreateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateStudentAsync(int id, StudentForUpdateDto dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteStudentAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<StudentDto>> GetStudentByCoursesAsync(int id, CancellationToken cancellationToken = default);
}
