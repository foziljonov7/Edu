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

        public async Task<Category> CreateCategory(Category newCategory)
        {
            await dbContext.Categorys.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();
            return newCategory;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await dbContext.Categorys
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category is null)
                return false;

            dbContext.Categorys.Remove(category);
            await dbContext.SaveChangesAsync();
            return true;
        }

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
                .Include(c => c.Teacher)
                .ToListAsync();

            if (categoryCourse is null)
                return null;

            return categoryCourse;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var updated = await dbContext.Categorys.
                Where(c => c.Id == category.Id)
                .FirstOrDefaultAsync();

            if (updated is null)
                return null;

            updated.Name = category.Name;
            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
