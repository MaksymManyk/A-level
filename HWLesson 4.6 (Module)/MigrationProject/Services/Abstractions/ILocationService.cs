using Models;

namespace Services.Abstractions
{
    public interface ILocationService
    {
        Task<int> AddLocationAsync(string locationName);

        Task<Location> GetLocationAsync(string locationName);

        Task<Location> GetLocationAsync(int id);

        Task<List<Location>> GetLocationAsync();

        Task UpdateLocationAsync(int id, string locationName);

        Task DeleteLocationAsync(int id);
    }
}
