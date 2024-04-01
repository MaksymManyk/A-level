using DTO;
using Models;

namespace Services.Abstractions
{
    public interface IPetService
    {
        Task<int> AddPetAsync(string petName, int categoryID, int breedId, float age, int locationId, string description = "", string imageURL = "");

        Task<List<Pet>> GetPetAsync();

        Task UpdatePetAsync(int id, string petName, int categoryID, int breedId, float age, int locationId, string imageURL = "", string description = "");

        Task DeletePetAsync(int id);

        Task<List<CategoryCountDTO>> GetCategoryCount();

        Task PrintAllPets();
    }
}
