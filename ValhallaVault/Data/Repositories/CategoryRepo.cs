﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<CategoryModel?> GetCategoryByIdWithEagerLoadingAsync(int id)
        {
            return await _dbContext.Categories
                .Where(x => x.Id == id)
                .Include(x => x.Segments)
                .ThenInclude(x => x.Subcategories)
                .ThenInclude(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefaultAsync();

        }

        public async Task AddCategoryAsync(CategoryModel? category)
        {
            if (category == null)
            {
                return;
            }
            _dbContext.Set<CategoryModel>().Add(category);
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

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            if (category == null)
            {
                return;
            }

            _dbContext.Entry(category).State = EntityState.Modified;
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Set<CategoryModel>().FindAsync(id);
        }

        public Task<CategoryModel?> GetCategoryByIdIncludingSegmentsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}