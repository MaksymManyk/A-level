using Entity;
using Repository.Abstraction;

namespace Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IngredientEntity[] _mockStorage = new IngredientEntity[100];
        private int _mockStorageCursor = 0;

        public string AddIngredient(string name, decimal multiplier, decimal calories, string type)
        {
            var ingredient = new IngredientEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Multiplier = multiplier,
                Calories = calories,
                Type = type
            };

            this._mockStorage[this._mockStorageCursor] = ingredient;
            this._mockStorageCursor++;
            return ingredient.ID;
        }

        public IngredientEntity GetIngredient(string id)
        {
            foreach (var item in this._mockStorage)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
