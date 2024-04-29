using Edu.DAL.DbContexts;
using Edu.Domain.Helpers.Commons;
using Edu.Infrastructure.Repositories;
using Edu.Services.Interfaces;
using Edu.Services.Servicecs;
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
}
