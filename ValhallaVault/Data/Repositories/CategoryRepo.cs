using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class CategoryRepo
    {
        private readonly ProgramDbContext _dbContext;

        public CategoryRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return _dbContext.Set<CategoryModel>().ToList();
        }

        public async Task<CategoryModel?> GetCategoryById(int id)
        {
            return await _dbContext.Set<CategoryModel>().FindAsync(id);
        }

        public async Task AddCategory(CategoryModel category)
        {
            _dbContext.Set<CategoryModel>().Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryModel> DeleteCategory(int id)
        {
            var category = await _dbContext.Set<CategoryModel>().FindAsync(id);
            if (category != null)
            {
                _dbContext.Set<CategoryModel>().Remove(category);
                return category;
            }
            else
            {
                throw new Exception("No category found with the specified ID.");
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}