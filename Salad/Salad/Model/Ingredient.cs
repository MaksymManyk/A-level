
namespace  Model
{
    public class Ingredient : IComparable<Ingredient>
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Multiplier { get; set; }

        public decimal Calories { get; set; }

        public int CompareTo(Ingredient ingredient)
        {
            return string.Compare(this.Name, ingredient.Name, StringComparison.Ordinal);
        }
    }
}
