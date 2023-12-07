using Edu.Data;
using Edu.Dtos;
using Edu.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<bool> DeleteTeacher(Guid id)
        {
            var teacher = await dbContext.Teachers
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (teacher is null)
                return false;

            dbContext.Teachers.Remove(teacher);
            await dbContext.SaveChangesAsync();
            return true;
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
        {
            var teachers = await dbContext.Teachers
                .Include(t => t.Courses)
                .ToListAsync();

            if (teachers is null)
                return null;

            return teachers;
        }

        public async Task<Teacher> UpdateTeacher(Guid id, UpdateTeacherDto teacher)
        {
            var updated = await dbContext.Teachers
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (updated is null)
                return null;

            updated.Fullname = teacher.Fullname;
            updated.PhoneNumber = teacher.PhoneNumber;
            updated.Age = teacher.Age;
            updated.Skills = teacher.Skills;

            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
