using Data;
using Data.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _dbContext;

        public PetRepository(IDbContextWrapper<AppDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddPetAsync(string petName, int categoryID, int breedId, float age, int locationId, string imageURL, string description)
        {
            var pet = new PetEntity { Name = petName,  CategoryId = categoryID, BreedId = breedId,  Age =age, LocationId = locationId, ImageURL = imageURL, Description = description };
            var result = await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<List<PetEntity>> GetPetAsync()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        public async Task<PetEntity> GetPetAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePetAsync(int id, string petName, int categoryID, int breedId, float age, int locationId, string imageURL, string description)
        {
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);

            if (pet != null)
            {
                pet.Name = petName;
                pet.CategoryId  = categoryID;
                pet.BreedId = breedId;
                pet.Age = age;
                pet.LocationId = locationId;
                pet.ImageURL = imageURL;
                pet.Description = description;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Pet ID: {id} not found");
            }

        }

        public async Task DeletePetAsync(int id)
        {
            var Pet = await _dbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);

            if (Pet != null)
            {
                _dbContext.Pets.Remove(Pet);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Pet ID: {id} not found");
            }
        }

        public async Task<List<CategoryCountDTO>> GetCategoryCount()
        {
            var CategoryCount = await  _dbContext.Pets.Join(_dbContext.Locations, pets => pets.LocationId, location => location.Id, (pets, location) => new { pets, location })
                .Where(pets => pets.location.LocationName == "Ukraine" && pets.pets.Age > 3.0)
                .Join(_dbContext.Categories, pets => pets.pets.CategoryId, category => category.Id, (pets, category) => new { pets, category })
                .GroupBy(pets => pets.category.CategoryName)
                .Select(group => new CategoryCountDTO { CategoryName = group.Key, Count = group.Select(p => p.pets.pets.BreedId).Distinct().Count() }).ToListAsync();

            return CategoryCount;
        }
    }
}
