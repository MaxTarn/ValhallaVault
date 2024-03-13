using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class CategoryRepo : ICategoryRepository
    {
        private readonly ProgramDbContext _dbContext;

        public CategoryRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _dbContext.Set<CategoryModel>().ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _dbContext.Set<CategoryModel>().FindAsync(id);
            }
            else
            {
                throw new Exception("Use valid ID");
            }
        }

        public async Task<CategoryModel?> GetCategoryByIdIncludingSegmentsAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.Segments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            if (category != null)
            {
                _dbContext.Set<CategoryModel>().Add(category);
            }
            else
            {
                throw new Exception("Category cannot be null");
            }
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            if (category != null)
            {
                _dbContext.Entry(category).State = EntityState.Modified;
            }
            else
            {
                throw new Exception("Select category to update");
            }
        }

        public async Task<CategoryModel?> DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var category = await _dbContext.Set<CategoryModel>().FindAsync(id);
            if (category != null)
            {
                _dbContext.Set<CategoryModel>().Remove(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            else
            {
                throw new Exception("No category found with the specified ID.");
            }
        }

        public int? CountCorrectAnswers(string userId)
        {
            if (userId == null)
            {
                return null;
            }
            return _dbContext.UserQuestions.Where(u => u.UserId == userId && u.IsCorrect == true).Count();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}