using Edu.Entities;

namespace Edu.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<List<Course>> GetCoursesCategory(int id);
        Task<Category> CreateCategory(Category newCategory);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
