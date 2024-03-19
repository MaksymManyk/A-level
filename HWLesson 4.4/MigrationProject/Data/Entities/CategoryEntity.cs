namespace Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public List<BreedEntity>? Breeds { get; set; } = new List<BreedEntity>();

        public List<PetEntity>? Pets { get; set; } = new List<PetEntity>();

    }
}
