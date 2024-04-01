using Data.Entities;

namespace Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<int> AddLocationAsync(string locationName);

        Task<LocationEntity?> GetLocationAsync(string locationName);

        Task<LocationEntity?> GetLocationAsync(int id);

        Task<List<LocationEntity>?> GetLocationAsync();

        Task UpdateLocationAsync(int id, string name);

        Task DeleteLocationAsync(int id);
    }
}
