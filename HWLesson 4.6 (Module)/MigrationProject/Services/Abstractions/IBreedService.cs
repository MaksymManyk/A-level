using Models;

namespace Services.Abstractions
{
    public interface IBreedService
    {
        Task<int> AddBreedAsync(int categoryID, string breedName);

        Task<List<Breed>> GetBreedAsync();

        Task<Breed> GetBreedAsync(int id);

        Task<Breed> GetBreedAsync(string breedName);

        Task UpdateBreedAsync(int id, int categoryID, string breedName);

        Task DeleteBreedAsync(int id);
    }
}
