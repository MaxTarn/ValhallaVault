using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class SubcategoryRepo
    {
        private readonly ProgramDbContext _dbContext;

        public SubcategoryRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSub(SubcategoryModel subcategory)
        {
            await _dbContext.Set<SubcategoryModel>().AddAsync(subcategory);
        }

        public void UpdateSub(SubcategoryModel subcategory)
        {
            _dbContext.Entry(subcategory).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteSub(int id)
        {
            var subcategory = _dbContext.Set<SubcategoryModel>().Find(id);
            if (subcategory != null)
            {
                _dbContext.Set<SubcategoryModel>().Remove(subcategory);
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
    }
}
