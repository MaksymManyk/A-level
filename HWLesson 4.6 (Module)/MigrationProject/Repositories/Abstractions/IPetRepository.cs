using Data.Entities;
using DTO;

namespace  Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<int> AddPetAsync(string petName, int categoryID, int breedId, float age, int locationId, string imageURL, string description);

        Task<List<PetEntity>> GetPetAsync();

        Task<PetEntity> GetPetAsync(int id);

        Task UpdatePetAsync(int id, string petName, int categoryID, int breedId, float age, int locationId, string imageURL, string description);

        Task DeletePetAsync(int id);

        Task<List<CategoryCountDTO>> GetCategoryCount();
    }
}
