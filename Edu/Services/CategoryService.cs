using Edu.Data;
using Edu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext dbContext;

        public CategoryService(AppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<List<Category>> GetCategories()
            => await dbContext.Categorys.ToListAsync();

        public async Task<Category> GetCategory(int id)
        {
            var category = await dbContext.Categorys
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category is null)
                return null;

            return category;
        }

        public async Task<List<Course>> GetCoursesCategory(int id)
        {
            var categoryCourse = await dbContext.Courses
                .Where(h => h.CategoryId == id)
                .ToListAsync();

            if (categoryCourse is null)
                return null;

            return categoryCourse;
        }
    }
}
