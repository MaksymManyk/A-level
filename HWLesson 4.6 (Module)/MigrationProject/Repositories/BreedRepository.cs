using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly AppDbContext _dbContext;

        public BreedRepository(IDbContextWrapper<AppDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBreedAsync(int categoryID, string breedName)
        {
            var breed = new BreedEntity { CategoryID = categoryID, BreedName = breedName };
            var result = await _dbContext.Breeds.AddAsync(breed);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<List<BreedEntity>> GetBreedAsync()
        {
            return await _dbContext.Breeds.ToListAsync();
        }

        public async Task<BreedEntity> GetBreedAsync(int id)
        {
            return await _dbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BreedEntity?> GetBreedAsync(string breedName)
        {
            return await _dbContext.Breeds.FirstOrDefaultAsync(x => x.BreedName == breedName);
        }

        public async Task<BreedEntity?> CheckBreedAsync(int id, string breedName)
        {
            return await _dbContext.Breeds.Where(x => x.Id != id).Where(y => y.BreedName == breedName).FirstOrDefaultAsync();
        }

        public async Task UpdateBreedAsync(int id, int categoryID, string breedName)
        {
            var breed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);

            if (breed != null)
            {
                breed.CategoryID = categoryID;
                breed.BreedName = breedName;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Breed ID: {id} not found");
            }
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);

            if (breed != null)
            {
                _dbContext.Breeds.Remove(breed);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Breed ID: {id} not found");
            }
        }
    }
}
