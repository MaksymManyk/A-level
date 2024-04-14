using Data;
using DTO;
using Microsoft.Extensions.Logging;
using Models;
using Repositories.Abstractions;
using Services.Abstractions;


namespace Services
{
    public class PetService : BaseDataService<AppDbContext> , IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetService> _loggerService;

        public PetService(IDbContextWrapper<AppDbContext> dbContextWrapper,
             ILogger<BaseDataService<AppDbContext>> logger,
             IPetRepository petRepository,
             ILogger<PetService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _petRepository = petRepository;
            _loggerService = loggerService;
        }


        public async Task<int> AddPetAsync(string petName, int categoryID, int breedId, float age, int locationId, string description = "", string imageURL = "")
        {
            var id = await _petRepository.AddPetAsync(petName, categoryID, breedId, age, locationId, imageURL, description);
            _loggerService.LogInformation($"Created pet with id = {id}");
            return id;
        }

        public async Task<List<Pet>> GetPetAsync()
        {
            var petEntity = await _petRepository.GetPetAsync();

            if (petEntity.Count == 0)
            {
                _loggerService.LogWarning($"Pets not founded");
                return null!;
            }
            else
            {
                List<Pet> pets = new List<Pet>();

                pets?.AddRange(petEntity.Select(pet => new Pet()
                {
                 PetID = pet.Id,
                 PetName = pet.Name,
                 Category = new Category
                 {
                     CategoryID = pet.Category.Id,
                     CategoryName = pet.Category.CategoryName,
                 },
                 Breed = new Breed() 
                 {
                     BreedID = pet.Breed.Id,
                     BreedName = pet.Breed.BreedName,
                     Category = new Category
                     {
                         CategoryName = pet.Breed.Category.CategoryName,
                         CategoryID = pet.Breed.Category.Id,
                     },
                 },
                 Location = new Location
                 {
                     Id = pet.Location.Id,
                     LocationName = pet.Location.LocationName,
                 },
                 Age = pet.Age,
                 Description = pet.Description,
                 ImageURL = pet.ImageURL,
                }));

                return pets.OrderBy(p => p.Location.LocationName).OrderBy(p => p.Breed.Category.CategoryID).ToList();
            }
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            var petEntity = await _petRepository.GetPetAsync(id);

            if (petEntity == null)
            {
                _loggerService.LogWarning($"Pet with ID:{id} not founded");
                return null!;
            }
            else
            {
                return new Pet()
                {
                   PetID = petEntity.Id,
                   PetName = petEntity.Name,
                   Category = new Category
                   {
                       CategoryID = petEntity.Category.Id,
                       CategoryName = petEntity.Category.CategoryName,
                   },
                   Breed = new Breed()
                   { 
                       BreedID = petEntity.Breed.Id,
                       BreedName = petEntity.Breed.BreedName,
                       Category = new Category
                       {
                           CategoryName = petEntity.Breed.Category.CategoryName,
                           CategoryID = petEntity.Breed.Category.Id,
                       },
                   },
                   Location = new Location 
                   {
                       Id = petEntity.Location.Id,
                       LocationName = petEntity.Location.LocationName,
                   },
                   Age = petEntity.Age,
                   Description = petEntity.Description,
                   ImageURL = petEntity.ImageURL,
                };
            }
        }

        public async Task UpdatePetAsync(int id, string petName, int categoryID, int breedId, float age, int locationId, string imageURL = "", string description = "")
        {
           try
                {
                    await _petRepository.UpdatePetAsync(id, petName, categoryID, breedId, age, locationId, imageURL, description);
                    _loggerService.LogInformation($"Pet with id = {id} changed");

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

        public async Task DeletePetAsync(int id)
        {
            try
            {
                await _petRepository.DeletePetAsync(id);
                _loggerService.LogInformation($"Pet with id = {id} deleted");
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

        public async Task<List<CategoryCountDTO>> GetCategoryCount()
        {
           return await _petRepository.GetCategoryCount();
        }

        public async Task PrintAllPets()
        {
            var pets = await GetPetAsync();

            Console.WriteLine($"{Environment.NewLine}{"PetName",-10}{"BreedName",-10}{"CategoryName",-15}{"Age",-10}{"LocationName",-10}");

            foreach (var pet in pets)
            { Console.WriteLine($"{pet.PetName,-10} {pet.Breed.BreedName,-10}   {pet.Category.CategoryName,-10}  {pet.Age,-10}  {pet.Location.LocationName,-10} "); }
            Console.WriteLine($"{Environment.NewLine}");
        }
    }
}
