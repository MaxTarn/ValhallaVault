using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    //TODO make method that returns all segments with specific category id
    //TODO make method that return a single subcategory with the questions and answers joined/added
    // TODO GetQuestionsBySubcategoryIdAsync method
    public class SubcategoryRepo
    {
        private readonly ProgramDbContext _dbContext;

        public SubcategoryRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSub(SubcategoryModel subcategory)
        {

            _dbContext.Set<SubcategoryModel>().Add(subcategory);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateSub(SubcategoryModel subcategory)
        {
            _dbContext.Entry(subcategory).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<SubcategoryModel> DeleteSub(int id)
        {
            var subcategory = await _dbContext.Set<SubcategoryModel>().FindAsync(id);
            if (subcategory != null)
            {
                _dbContext.Set<SubcategoryModel>().Remove(subcategory);
                return subcategory;
            }
            else
            {
                throw new Exception("No subcategory found with the specified ID.");
            }
        }

        public async Task<SubcategoryModel?> GetById(int id)
        {
            return await _dbContext.Set<SubcategoryModel>().FindAsync(id);
        }

        public async Task<IEnumerable<SubcategoryModel>> GetAllSubs()
        {
            return _dbContext.Set<SubcategoryModel>().ToList();
        }
        public async Task<SubcategoryModel?> GetByIdWithQuestionsAndAnswers(int id)
        {
            return await _dbContext?.Set<SubcategoryModel>()
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}