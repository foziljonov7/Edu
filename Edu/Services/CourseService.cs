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

        public async Task<Course> CreateCourse(CreateCourseDto newCourse, IFormFile imageFile)
        {
            var created = new Course
            {
                Id = Guid.NewGuid(),
                Name = newCourse.Name,
                Price = newCourse.Price,
                Time = newCourse.Time,
                StartTime = DateTime.UtcNow,
                Description = newCourse.Description,
                TeacherId = newCourse.TeacherId,
                CategoryId = newCourse.CategoryId
            };

            if(imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);

                    created.ImageName = imageFile.FileName;
                    created.ImageData = memoryStream.ToArray();
                }
            }

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
                .Include(c => c.Teacher)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            if (course is null)
                return null;

            var result = new GetCourseDto(course);
            return result;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await dbContext.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Category)
                .ToListAsync();

            if (courses is null)
                return null;

            return courses;
        }

        public async Task<List<Course>> GetCourseStudent(Guid id)
        {
            var courseStudents = await dbContext.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Students)
                .ToListAsync();

            if (courseStudents is null)
                return null;

            return courseStudents;
        }

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
            updated.ImageData = course.ImageData;
            updated.CategoryId = course.CategoryId;

            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
