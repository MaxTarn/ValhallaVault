using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{

    public class SubcategoryRepo : ISubcategoryRepository
    {
        private readonly ProgramDbContext _dbContext;

        public SubcategoryRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SubcategoryModel>> GetAllSubscategoriesAsync()
        {
            return await _dbContext.Subcategories.ToListAsync();
        }

        public async Task<SubcategoryModel?> GetSubcategoryByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Subcategories.FindAsync(id);
        }

        public async Task<SubcategoryModel?> GetSubCategoryByIdIncludingThingsAsync(int? id)
        {

            return await _dbContext.Subcategories
                .Include(x => x.Questions)
                .ThenInclude(xx => xx.Answers)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<SubcategoryModel?> GetSubCategoryByIdIncludigQuestionsAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Subcategories.Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SubcategoryModel?> GetByIdWithQuestionsAndAnswers(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext?.Set<SubcategoryModel>()
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddSubcategoryAsync(SubcategoryModel? subcategory)
        {
            if (subcategory == null)
            {
                return;
            }
            _dbContext.Subcategories.Add(subcategory);
        }

        public void UpdateSubcategoryAsync(SubcategoryModel? subcategory)
        {
            if (subcategory == null)
            {
                return;
            }
            _dbContext.Entry(subcategory).State = EntityState.Modified;
        }

        public async Task<SubcategoryModel?> DeleteSubcategoryAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var subcategory = await _dbContext.Subcategories.FindAsync(id);
            if (subcategory != null)
            {
                _dbContext.Subcategories.Remove(subcategory);
                await _dbContext.SaveChangesAsync();
                return subcategory;
            }
            else
            {
                throw new Exception("No subcategory found with the specified ID.");
            }
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<SubcategoryModel?> GetSubcategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubcategoryModel?> GetSubCategoryByIdIncludingThingsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubcategoryModel?> GetSubCategoryByIdIncludigQuestionsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubcategoryModel?> GetByIdWithQuestionsAndAnswers(int id)
        {
            throw new NotImplementedException();
        }
    }

}
