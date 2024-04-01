using Data.Entities;

namespace  Repositories.Abstractions
{
    public interface ICategoryRepository
    {
         Task<int> AddCategoryAsync(string CategoryName);

         Task<CategoryEntity?> GetCategoryAsync(string CategoryName);

         Task<CategoryEntity?> GetCategoryAsync(int Id);

         Task<List<CategoryEntity>?> GetCategoryAsync();

         Task UpdateCategoryAsync(int Id, string name);

         Task DeleteCategoryAsync(int id);
    }
}
