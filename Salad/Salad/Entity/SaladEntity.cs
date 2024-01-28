using Model;

namespace  Entity
{
    public class SaladEntity
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public List<Ingredient> Ingredient { get; set; }
    }
}
