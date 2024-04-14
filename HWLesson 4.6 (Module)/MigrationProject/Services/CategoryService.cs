using Data;
using Microsoft.Extensions.Logging;
using Models;
using Repositories.Abstractions;
using Services.Abstractions;


namespace Services
{
    public class CategoryService : BaseDataService<AppDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(IDbContextWrapper<AppDbContext> dbContextWrapper,
             ILogger<BaseDataService<AppDbContext>> logger,
             ICategoryRepository categoryRepository,
             ILogger<CategoryService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategoryAsync(string categoryName)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryName);

            if (category != null)
            {
                _loggerService.LogWarning($"Animal with a name:{categoryName} exists");
                return 0;
            }

            var id = await _categoryRepository.AddCategoryAsync(categoryName);
            _loggerService.LogInformation($"Created category with id = {id}");
            return id;
        }

        public async Task<Category> GetCategoryAsync(string categoryName)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryName);

            if (category == null)
            {
                _loggerService.LogWarning($"Animal with a name:{categoryName} not founded");
                return null!;
            }

            return new Category()
            {
                CategoryID = category.Id,
                CategoryName = category.CategoryName,
            };
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                _loggerService.LogWarning($"Animal with ID:{id} not founded");
                return null!;
            }

            return new Category()
            {
                CategoryID = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoryAsync();

            if (categoriesEntity.Count == 0)
            {
                _loggerService.LogWarning($"Animals not founded");
                return null!;
            }
            else
            {
                List<Category> categories = new List<Category>();

                categories?.AddRange(categoriesEntity.Select(s => new Category() { CategoryID = s.Id, CategoryName = s.CategoryName }));
                return categories;
            }
        }

        public async Task  UpdateCategoryAsync(int id, string categoryName)
        {
            try
            {
                await _categoryRepository.UpdateCategoryAsync(id, categoryName);
                _loggerService.LogInformation($"Change Name category with id = {id}");
            }
            catch (InvalidOperationException ex)
            {
               _loggerService.LogWarning($"{ex.Message}");
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                await _categoryRepository.DeleteCategoryAsync(id);
                _loggerService.LogInformation($"Category with id = {id} deleted");
            }
            catch (InvalidOperationException ex)
            {
                _loggerService.LogWarning($"{ex.Message}");
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
            }
        }
    }
}
