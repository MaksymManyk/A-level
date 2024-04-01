using Data;
using Microsoft.Extensions.Logging;
using Models;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services
{
    public class BreedService: BaseDataService<AppDbContext>, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ILogger<BreedService> _loggerService;

        public BreedService(IDbContextWrapper<AppDbContext> dbContextWrapper,
             ILogger<BaseDataService<AppDbContext>> logger,
             IBreedRepository breedRepository,
             ILogger<BreedService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _breedRepository = breedRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddBreedAsync(int categoryID, string breedName)
        {
            var breed = await _breedRepository.GetBreedAsync(breedName);

            if (breed != null)
            {
                _loggerService.LogWarning($"Breed with a name:{breedName} exists");
                return 0;
            }

            var id = await _breedRepository.AddBreedAsync(categoryID, breedName);
            _loggerService.LogInformation($"Created breed with id = {id}");
            return id;
        }

        public async Task<List<Breed>> GetBreedAsync()
        {
            var breedsEntity = await _breedRepository.GetBreedAsync();

            if (breedsEntity.Count == 0)
            {
                _loggerService.LogWarning($"Breeds not founded");
                return null!;
            }
            else
            {
                List<Breed> breeds = new List<Breed>();

                breeds?.AddRange(breedsEntity.Select(breed => new Breed() 
                {
                    BreedID = breed.Id,
                    BreedName = breed.BreedName,
                    Category = new Category
                    {
                        CategoryID = breed.Category.Id,
                        CategoryName = breed.Category.CategoryName,
                    },
                }));

                return breeds;
            }
        }

        public async Task<Breed> GetBreedAsync(int id)
        {
            var breed = await _breedRepository.GetBreedAsync(id);
            if (breed == null)
            {
                _loggerService.LogWarning($"Breeds with ID:{id} not founded");
                return null!;
            }
            else
            {
                return new Breed
                {
                   BreedID = breed.Id,
                   BreedName = breed.BreedName,
                   Category = new Category 
                   {
                       CategoryID = breed.CategoryID,
                       CategoryName = breed.Category.CategoryName,
                   },
                };
            }
        }

        public async Task<Breed> GetBreedAsync(string breedName)
        {
            var breed = await _breedRepository.GetBreedAsync(breedName);
            if (breed == null)
            {
                _loggerService.LogWarning($"Breeds with ID:{breedName} not founded");
                return null!;
            }
            else
            {
                return new Breed
                {
                  BreedID = breed.Id,
                  BreedName = breed.BreedName,
                  Category = new Category
                    {
                     CategoryID = breed.CategoryID,
                     CategoryName = breed.Category.CategoryName,
                    },
                };
            }
        }


        public async Task UpdateBreedAsync(int id, int categoryID, string breedName)
        {
            var breed = await _breedRepository.CheckBreedAsync(id, breedName);
            if (breed != null)
            {
                _loggerService.LogWarning($"Breed with a name:{breedName} exists");
            }
            else
            {
                try
                {
                    await _breedRepository.UpdateBreedAsync(id, categoryID, breedName);
                    _loggerService.LogInformation($"Breed with id = {id} changed");
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

        public async Task DeleteBreedAsync(int id)
        {
            try
            {
                await _breedRepository.DeleteBreedAsync(id);
                _loggerService.LogInformation($"Breed with id = {id} deleted");
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
