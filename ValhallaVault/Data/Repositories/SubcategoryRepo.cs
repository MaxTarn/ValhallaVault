using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class SubcategoryRepo
    {
        private readonly DbContext _dbContext;

        public SubcategoryRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSub(SubcategoryModel subcategory)
        {
            _dbContext.Set<SubcategoryModel>().Add(subcategory);
        }

        public void UpdateSub(SubcategoryModel subcategory)
        {
            _dbContext.Set<SubcategoryModel>().Update(subcategory);
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

        public SubcategoryModel GetById(int id)
        {
            return _dbContext.Set<SubcategoryModel>().Find(id);
        }

        public async Task<IEnumerable<SubcategoryModel>> GetAllSubs()
        {
            return _dbContext.Set<SubcategoryModel>().ToList();
        }
    }
}
