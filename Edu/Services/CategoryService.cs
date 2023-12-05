using Edu.Data;
using Edu.Entities;

namespace Edu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext dbContext;

        public CategoryService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCoursesCategory()
        {
            throw new NotImplementedException();
        }
    }
}
