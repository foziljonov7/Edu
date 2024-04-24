using AutoMapper;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.DAL.DTOs.RegistryDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Domain.Models;

namespace Edu.Services.Helpers.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Course, CourseForCreateDto>().ReverseMap();
        CreateMap<Course, CourseForUpdateDto>().ReverseMap();
        CreateMap<Teacher, TeacherDto>().ReverseMap();
        CreateMap<Teacher, TeacherForCreateDto>().ReverseMap();
        CreateMap<Teacher, TeacherForUpdateDto>().ReverseMap();
        CreateMap<Student, StudentForCreateDto>().ReverseMap();
        CreateMap<Student, StudentForUpdateDto>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Registry, RegistryDTO>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, PaymentForCourseDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryForCreateDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
        CreateMap<Subject, SubjectForCreateDto>().ReverseMap();
        CreateMap<Subject, SubjectForUpdateDto>().ReverseMap();
    }
}
