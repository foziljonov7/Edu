using Edu.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Edu.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasKey(c => c.Id);
            builder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Entity<Course>()
                .Property(c => c.Price)
                .IsRequired();
            builder.Entity<Course>()
                .Property(c => c.StartTime)
                .HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Course>()
                .Property(c => c.Time)
                .HasMaxLength(10);
            builder.Entity<Course>()
                .Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();
            builder.Entity<Course>()
               .HasOne(c => c.Teacher)
               .WithMany(t => t.Courses)
               .HasForeignKey(c => c.TeacherId);
            builder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId);
            builder.Entity<Teacher>()
                .HasKey(t => t.Id);
            builder.Entity<Teacher>()
                .Property(t => t.Fullname)
                .HasMaxLength(120)
                .IsRequired();
            builder.Entity<Teacher>()
                .Property(t => t.Age)
                .IsRequired();
            builder.Entity<Teacher>()
                .Property(t => t.Skills)
                .HasMaxLength(500)
                .IsRequired();
            builder.Entity<Teacher>()
                .Property(t => t.PhoneNumber)
                .HasMaxLength(13)
                .IsRequired();
            builder.Entity<Category>()
                .HasKey(c => c.Id);
            builder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Entity<Category>()
                .HasData(
                    new { Id = 1, Name = "Media" },
                    new { Id = 2, Name = "Dasturlash" },
                    new { Id = 3, Name = "Savodxonlik" },
                    new { Id = 4, Name = "Chet tili" }
                );

            base.OnModelCreating(builder);
        }
    }
}
