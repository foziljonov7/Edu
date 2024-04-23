using Edu.DAL.DbContexts;
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
}
