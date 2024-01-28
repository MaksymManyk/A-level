using Enum;
using Model;
using Repository;
using Service.Adstraction;

namespace  Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientService(IngredientRepository ingredientRepository)
        {
            this._ingredientRepository = ingredientRepository;
        }

        public string  AddIngredient(Ingredient ing)
        {
          var id = _ingredientRepository.AddIngredient(ing.Name , ing.Multiplier, ing.Calories, ing.Type);
          return id;
        }

        public Ingredient  GetIngredient(string id)
        {
            var ingredient = _ingredientRepository.GetIngredient(id);

            if (ingredient == null)
            {
                return null;
            }

            return new Ingredient()
            {
                Name = ingredient.Name,
                Type = ingredient.Type,
                Multiplier = ingredient.Multiplier,
                Calories = ingredient.Calories,
                ID = ingredient.ID
            };
        }

        public Oil CreateOil(string? ingridientName, decimal ingridientMultiplier)
        {
            Oil oil = new Oil()
            {
                Name = ingridientName,
                Multiplier = ingridientMultiplier,
                Type = IngredientTypes.Oil.ToString(),
                Calories = new Random().Next(20, 100),
                Density = 20,
            };

            return oil;
        }

        public Spice CreateSpice(string? ingridientName, decimal ingridientMultiplier)
        {
            Spice spice = new Spice()
            {
                Name = ingridientName,
                Multiplier = ingridientMultiplier,
                Type = IngredientTypes.Spices.ToString(),
                Calories = new Random().Next(20, 100),
                Grinding = "High"
            };

            return spice;
        }

        public Vegetable CreateVegetable(string? ingridientName, decimal ingridientMultiplier)
        {
            Vegetable vegetable = new Vegetable()
            {
                Name = ingridientName,
                Multiplier = ingridientMultiplier,
                Type = IngredientTypes.Vegetable.ToString(),
                Calories = new Random().Next(20, 100),
                Smell = "Nice"
            };

            return vegetable;
        }
    }
}
