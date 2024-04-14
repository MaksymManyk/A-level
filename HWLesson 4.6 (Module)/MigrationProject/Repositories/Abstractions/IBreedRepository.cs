using Data.Entities;

namespace Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<int> AddBreedAsync(int categoryID, string breedName);

        Task<List<BreedEntity>> GetBreedAsync();

        Task<BreedEntity> GetBreedAsync(int id);

        Task<BreedEntity?> GetBreedAsync(string breedName);

        Task UpdateBreedAsync(int id, int categoryID, string breedName);

        Task<BreedEntity?> CheckBreedAsync(int id, string breedName);

        Task DeleteBreedAsync(int id);
    }
}
