
namespace Models
{
    public class Breed 
    {
        public int BreedID { get; set; }

        public string BreedName { get; set; } = null!;

        public Category Category { get; set; } = null!;
    }
}
