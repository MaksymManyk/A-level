
namespace Model
{
    public class Salad 
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public List<Ingredient> Ingredient { get; set; }
    }
}
