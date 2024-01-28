using Entity;

namespace Repository.Abstraction
{
    public interface IIngredientRepository
    {
        public string AddIngredient(string name, decimal multiplier, decimal calories, string type);

        public IngredientEntity GetIngredient(string id);
    }
}
