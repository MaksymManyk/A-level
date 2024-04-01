using Data;
using Microsoft.Extensions.Logging;
using Models;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services
{
    public class LocationService : BaseDataService<AppDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(IDbContextWrapper<AppDbContext> dbContextWrapper,
             ILogger<BaseDataService<AppDbContext>> logger,
             ILocationRepository locationRepository,
             ILogger<LocationService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddLocationAsync(string locationName)
        {
            var location = await _locationRepository.GetLocationAsync(locationName);

            if (location != null)
            {
                _loggerService.LogWarning($"Location with a name:{locationName} exists");
                return 0;
            }

            var id = await _locationRepository.AddLocationAsync(locationName);
            _loggerService.LogInformation($"Created Location with id = {id}");
            return id;
        }

        public async Task<Location> GetLocationAsync(string locationName)
        {
            var location = await _locationRepository.GetLocationAsync(locationName);

            if (location == null)
            {
                _loggerService.LogWarning($"Location with a name:{locationName} not founded");
                return null!;
            }

            return new Location()
            {
                Id = location.Id,
                LocationName = location.LocationName
            };
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null)
            {
                _loggerService.LogWarning($"Location with ID:{id} not founded");
                return null!;
            }

            return new Location()
            {
                Id = location.Id,
                LocationName = location.LocationName
            };
        }

        public async Task<List<Location>> GetLocationAsync()
        {
            var locationsEntity = await _locationRepository.GetLocationAsync();

            if (locationsEntity.Count == 0)
            {
                _loggerService.LogWarning($"Locations not founded");
                return null!;
            }
            else
            {
                List<Location> locations = new List<Location>();

                foreach (var Location in locationsEntity)
                {
                    locations.Add(new Location { Id = Location.Id, LocationName = Location.LocationName });
                }

                return locations;
            }
        }

        public async Task UpdateLocationAsync(int id, string locationName)
        {
            try
            {
                await _locationRepository.UpdateLocationAsync(id, locationName);
                _loggerService.LogInformation($"Change Name Location with id = {id}");
            }
            catch (InvalidOperationException ex)
            {
                _loggerService.LogWarning($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteLocationAsync(int id)
        {
            try
            {
                await _locationRepository.DeleteLocationAsync(id);
                _loggerService.LogInformation($"Location with id = {id} deleted");

            }
            catch (InvalidOperationException ex)
            {
                _loggerService.LogWarning($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
