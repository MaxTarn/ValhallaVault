using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface ISubcategoryRepository
    {
        public interface ISubcategoryRepository
        {
            Task<IEnumerable<SubcategoryModel>> GetAllSubcategoriesAsync();
            Task<SubcategoryModel?> GetSubcategoryByIdAsync(int id);
            Task<SubcategoryModel?> GetSubcategoryByIdIncludingThingsAsync(int id);
            Task<SubcategoryModel?> GetSubcategoryByIdIncludingQuestionsAsync(int id);
            Task AddSubcategoryAsync(SubcategoryModel subcategory);
            void UpdateSubcategoryAsync(SubcategoryModel subcategory);
            Task<SubcategoryModel?> DeleteSubcategoryAsync(int id);
            Task SaveAsync();
        }
    }
}
