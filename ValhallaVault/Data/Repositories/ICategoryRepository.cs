using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(int id);
        Task<CategoryModel?> GetCategoryByIdWithEagerLoadingAsync(int id);
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task<CategoryModel?> DeleteCategoryAsync(int id);
        Task SaveAsync();
    }
}
