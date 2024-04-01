
namespace Models
{
    public class Pet
    {
        public int PetID { get; set; }

        public string PetName { get; set; }

        public Category? Category { get; set; }

        public Breed? Breed { get; set; }

        public float Age { get; set; }

        public Location? Location { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }
    }
}
