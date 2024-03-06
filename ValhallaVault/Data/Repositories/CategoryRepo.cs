using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class CategoryRepo
    {
        private readonly DbContext _dbContext;

        public CategoryRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _dbContext.Set<CategoryModel>().ToList();
        }

        public CategoryModel GetCategoryById(int id)
        {
            return _dbContext.Set<CategoryModel>().Find(id);
        }

        public void AddCategory(CategoryModel category)
        {
            _dbContext.Set<CategoryModel>().Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(CategoryModel category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Set<CategoryModel>().Find(id);
            if (category != null)
            {
                _dbContext.Set<CategoryModel>().Remove(category);
            }
            else
            {
                throw new Exception("No category found with the specified ID.");
            }
        }
    }
}
