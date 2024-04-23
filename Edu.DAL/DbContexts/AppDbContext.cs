using Edu.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Edu.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Registry> Registry { get; set; }
    public DbSet<Category> Categories { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
