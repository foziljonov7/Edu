using Edu.Data;
using Edu.Dtos;
using Edu.Entities;

namespace Edu.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext dbContext;

        public TeacherService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public Task<Teacher> CreateTeacher(CreateTeacherDto newTeacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeacher(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacher(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetTeachers()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> UpdateTeacher(Guid id, UpdateTeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
