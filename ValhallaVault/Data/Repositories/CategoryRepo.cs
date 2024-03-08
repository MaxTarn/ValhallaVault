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

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _dbContext.Set<CategoryModel>().ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Set<CategoryModel>().FindAsync(id);
        }

        //make method that returns all segments with specific category id

        public async Task<CategoryModel?> GetCategoryByIdIncludingSegmentsAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.Segments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            _dbContext.Set<CategoryModel>().Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
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

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}