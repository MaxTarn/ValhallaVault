using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<SubcategoryModel>> GetAllSubscategoriesAsync();
        Task<SubcategoryModel?> GetSubcategoriesByIdAsync(int id);
        Task<SubcategoryModel?> GetSubCategoryByIdIncludingThingsAsync(int id);
        Task<SubcategoryModel?> GetSubCategoryByIdIncludigQuestionsAsync(int id);
        Task AddSubcategoryAsync(SubcategoryModel subcategory);
        void UpdateSubcategoryAsync(SubcategoryModel subcategory);
        Task<SubcategoryModel?> DeleteSubcategoryAsync(int id);
        Task SaveAsync();
    }

}
