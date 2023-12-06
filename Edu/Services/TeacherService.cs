using Edu.Data;
using Edu.Dtos;
using Edu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edu.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext dbContext;

        public TeacherService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Teacher> CreateTeacher(CreateTeacherDto newTeacher)
        {
            var created = new Teacher
            {
                Id = Guid.NewGuid(),
                Fullname = newTeacher.Fullname,
                Age = newTeacher.Age,
                Skills = newTeacher.Skills,
                PhoneNumber = newTeacher.PhoneNumber
            };

            await dbContext.Teachers.AddAsync(created);
            await dbContext.SaveChangesAsync();

            return created;
        }

        public Task<bool> DeleteTeacher(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetTeacherDto> GetTeacher(Guid id)
        {
            var teacher = await dbContext.Teachers
                .Where(t => t.Id == id)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync();

            if (teacher is null)
                return null;

            var result = new GetTeacherDto(teacher);
            return result;
        }

        public async Task<List<Teacher>> GetTeachers()
            => await dbContext.Teachers.ToListAsync();

        public Task<Teacher> UpdateTeacher(Guid id, UpdateTeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
