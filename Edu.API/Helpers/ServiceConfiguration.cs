using Edu.API.Helpers.Validators.CategoryValidators;
using Edu.API.Helpers.Validators.CourseValidators;
using Edu.API.Helpers.Validators.PaymentValidators;
using Edu.API.Helpers.Validators.RegistryValidators;
using Edu.API.Helpers.Validators.StudentValidators;
using Edu.API.Helpers.Validators.SubjectValidators;
using Edu.API.Helpers.Validators.TeacherValdiators;
using Edu.DAL.DbContexts;
using Edu.DAL.DTOs.CategoryDTOs;
using Edu.DAL.DTOs.CourseDTOs;
using Edu.DAL.DTOs.PaymentDTOs;
using Edu.DAL.DTOs.RegistryDTOs;
using Edu.DAL.DTOs.StudentDTOs;
using Edu.DAL.DTOs.SubjectDTOs;
using Edu.DAL.DTOs.TeacherDTOs;
using Edu.Infrastructure.Repositories;
using Edu.Services.Interfaces;
using Edu.Services.Servicecs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Edu.API.Helpers;

public static class ServiceConfiguration
{
    public static void DbConfigure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("localhost");

        services.AddDbContext<AppDbContext>(options
            => options.UseNpgsql(connectionString));
    }

    public static void ServiceConfigure(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IRegistryService, RegistryService>();
    }

    public static void AddValidatorConfigure(
        this IServiceCollection services)
    {
        services.AddScoped<IValidator<CourseForCreateDto>, CourseForCreateValidator>();
        services.AddScoped<IValidator<CourseForUpdateDto>, CourseForUpdateValidator>();
        services.AddScoped<IValidator<CategoryForCreateDto>, CategoryForCreateValidator>();
        services.AddScoped<IValidator<CategoryForUpdateDto>, CategoryForUpdateValdiator>();
        services.AddScoped<IValidator<TeacherForCreateDto>, TeacherForCreateValidator>();
        services.AddScoped<IValidator<TeacherForUpdateDto>, TeacherForUpdateValidator>();
        services.AddScoped<IValidator<SubjectForCreateDto>, SubjectForCreateValidator>();
        services.AddScoped<IValidator<SubjectForUpdateDto>, SubjectForUpdateValidator>();
        services.AddScoped<IValidator<PaymentForCourseDto>, PaymentForCourseValidator>();
        services.AddScoped<IValidator<StudentForCreateDto>, StudentForCreateValidator>();
        services.AddScoped<IValidator<StudentForUpdateDto>, StudentForUpdateValidator>();
        services.AddScoped<IValidator<RegistryForPostDto>, RegistryForPostValidator>();
    }
}
