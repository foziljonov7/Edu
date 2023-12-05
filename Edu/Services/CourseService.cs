using Edu.Data;
using Edu.Dtos;
using Edu.Entities;

namespace Edu.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext dbContext;

        public CourseService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public Task<Course> CreateCourse(CreateCourseDto newCourse)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourse(Guid id, UpdateCourseDto course)
        {
            throw new NotImplementedException();
        }
    }
}
