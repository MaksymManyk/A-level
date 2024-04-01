using Data.Entities;
using Data;
using Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;

namespace  Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;

        public LocationRepository(IDbContextWrapper<AppDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddLocationAsync(string locationName)
        {
            var location = new LocationEntity()
            {
                LocationName = locationName
            };
            var result = await _dbContext.Locations.AddAsync(location);

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<LocationEntity?> GetLocationAsync(string locationName)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.LocationName == locationName);
        }

        public async Task<LocationEntity?> GetLocationAsync(int id)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LocationEntity>?> GetLocationAsync()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task UpdateLocationAsync(int id, string name)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location != null)
            {
                location.LocationName = name;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"location ID: {id} not found");
            }
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location != null)
            {
                _dbContext.Locations.Remove(location);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Location ID: {id} not found");
            }
        }
    }
}
