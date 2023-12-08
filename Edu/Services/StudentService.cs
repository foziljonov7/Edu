using Edu.Data;
using Edu.Dtos;
using Edu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edu.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext dbContext;

        public StudentService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Student> CreateStudent(CreateStudentDto newStudent)
        {
            var created = new Student
            {
                Id = Guid.NewGuid(),
                Fullname = newStudent.Fullname,
                Age = newStudent.Age,
                PhoneNumber = newStudent.PhoneNumber,
                CourseId = newStudent.CourseId
            };

            await dbContext.Students.AddAsync(created);
            await dbContext.SaveChangesAsync();

            return created;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            var student = await dbContext.Students
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (student is null)
                return false;

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<GetStudentDto> GetStudent(Guid id)
        {
            var student = await dbContext.Students
                .Where(c => c.Id == id)
                .Include(c => c.Course)
                .FirstOrDefaultAsync();

            if (student is null)
                return null;

            var result = new GetStudentDto(student);
            return result;
        }

        public async Task<List<Student>> GetStudents()
        {
            var student = await dbContext.Students
                .Include(c => c.Course)
                .ToListAsync();

            if (student is null)
                return null;

            return student;
        }

        public async Task<Student> UpdateStudent(Guid id, UpdateStudentDto student)
        {
            var updated = await dbContext.Students
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (updated is null)
                return null;

            updated.Fullname = student.Fullname;
            updated.Age = student.Age;
            updated.PhoneNumber = student.PhoneNumber;
            updated.CourseId = student.CourseId;

            await dbContext.SaveChangesAsync();

            return updated;
        }
    }
}
