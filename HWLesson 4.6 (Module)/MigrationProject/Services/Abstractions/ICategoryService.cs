using Models;

namespace Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(string CategoryName);

        Task<Category> GetCategoryAsync(string CategoryName);

        Task<Category> GetCategoryAsync(int Id);

        Task<List<Category>> GetCategoryAsync();

        Task UpdateCategoryAsync(int id, string name);

        Task DeleteCategoryAsync(int id);
    }
}
