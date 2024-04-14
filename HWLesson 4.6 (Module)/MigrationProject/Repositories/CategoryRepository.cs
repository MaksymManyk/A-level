using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(IDbContextWrapper<AppDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName)
        {
            var category = new CategoryEntity()
            {
                CategoryName = categoryName
            };
            var result = await _dbContext.Categories.AddAsync(category);

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(string categoryName)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryName == categoryName);
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoryEntity>?> GetCategoryAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task UpdateCategoryAsync(int id, string name)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
               category.CategoryName = name;
               await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Category ID: {id} not found");
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                _dbContext .Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Category ID: {id} not found");
            }
        }
    }
}
