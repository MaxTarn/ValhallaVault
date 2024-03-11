using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<SubcategoryModel>> GetAllSubscategoriesAsync();
        Task<SubcategoryModel?> GetSubcategoryByIdAsync(int id);
        Task<SubcategoryModel?> GetSubCategoryByIdIncludingThingsAsync(int id);
        Task<SubcategoryModel?> GetSubCategoryByIdIncludigQuestionsAsync(int id);

        public Task<SubcategoryModel?> GetByIdWithQuestionsAndAnswers(int id);
        Task AddSubcategoryAsync(SubcategoryModel subcategory);
        void UpdateSubcategoryAsync(SubcategoryModel subcategory);
        Task<SubcategoryModel?> DeleteSubcategoryAsync(int id);
        Task SaveAsync();
    }
}

