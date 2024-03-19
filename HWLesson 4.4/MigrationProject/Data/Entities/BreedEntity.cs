
namespace Data.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }

        public string BreedName { get; set; }

        public int CategoryID { get; set; }

        public CategoryEntity Category { get; set; }

        public List<PetEntity>? Pets { get; set; } = new List<PetEntity>();
    }
}
