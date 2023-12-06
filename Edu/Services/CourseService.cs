using Edu.Data;
using Edu.Dtos;
using Edu.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Edu.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext dbContext;

        public CourseService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Course> CreateCourse(CreateCourseDto newCourse)
        {
            var created = new Course
            {
                Id = Guid.NewGuid(),
                Name = newCourse.Name,
                Price = newCourse.Price,
                Time = newCourse.Time,
                StartTime = DateTime.UtcNow,
                Description = newCourse.Description,
                ImageName = newCourse.ImageName,
                TeacherId = newCourse.TeacherId,
                CategoryId = newCourse.CategoryId
            };

            await dbContext.Courses.AddAsync(created);
            await dbContext.SaveChangesAsync();

            return created;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var course = await dbContext.Courses
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (course is null)
                return false;

            dbContext.Courses.Remove(course);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<GetCourseDto> GetCourse(Guid id)
        {
            var course = await dbContext.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            if (course is null)
                return null;

            var result = new GetCourseDto(course);
            return result;
        }

        public async Task<List<Course>> GetCourses()
            => await dbContext.Courses.ToListAsync();

        public async Task<Course> UpdateCourse(Guid id, UpdateCourseDto course)
        {
            var updated = await dbContext.Courses
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if(updated is null)
                return null;

            updated.Name = course.Name;
            updated.Price = course.Price;
            updated.Time = course.Time;
            updated.Description = course.Description;
            updated.ImageName = course.ImageName;
            updated.TeacherId = course.TeacherId;
            updated.CategoryId = course.CategoryId;

            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
