using Repository;
using Service;
using Model;
using Enum;

namespace Salads
{
    public class App
    {
        private readonly IngredientService _ingredientService;
        private readonly SaladService _saladService;


        public App(SaladService saladService)
        {
            this._saladService = saladService;
            this._ingredientService = new IngredientService(new IngredientRepository());
        }

        public void Start()
        {
            List<Model.Salad> salads = new List<Model.Salad>();

            do
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                Console.WriteLine("Enter Name of Salad.");
                string? nameSalad = Console.ReadLine();
                Console.WriteLine("Enter weight, gr.");
                if (decimal.TryParse(Console.ReadLine(), out decimal saladWeight))
                {
                    do
                    {
                        Console.WriteLine($"What ingredient do you want to add? {IngredientTypes.Oil}, {IngredientTypes.Spices} or {IngredientTypes.Vegetable}.");
                        string? ingredientType = Console.ReadLine();
                        Console.WriteLine("Enter name of ingredient.");
                        string? ingridientName = Console.ReadLine();
                        Console.WriteLine("Enter multiplier 0-1.");
                        bool d = decimal.TryParse(Console.ReadLine(), out decimal ingridientMultiplier);

                        Ingredient? ing = ingredientType == IngredientTypes.Oil.ToString() ? this._ingredientService.CreateOil(ingridientName, ingridientMultiplier) :
                                          ingredientType == IngredientTypes.Spices.ToString() ? this._ingredientService.CreateSpice(ingridientName, ingridientMultiplier) :
                                          ingredientType == IngredientTypes.Vegetable.ToString() ? this._ingredientService.CreateVegetable(ingridientName, ingridientMultiplier) : null;

                        if (ing != null)
                        {
                            ingredients.Add(this._ingredientService.GetIngredient(this._ingredientService.AddIngredient(ing)));
                        }

                        Console.WriteLine("Do you want add next ingredient?: Y/N");
                    } while (Console.ReadLine().ToLower() == "y");

                    salads.Add(_saladService.GetSalad(_saladService.AddSalad(nameSalad, ingredients, saladWeight)));
                }

                Console.WriteLine("Do you want add next salad?: Y/N");

            } while (Console.ReadLine().ToLower() == "y");

            foreach (var salad in salads)
            {
                _saladService.PrintSalad(salad);
            }

            Console.WriteLine($"{Environment.NewLine}What ingredient are you looking for?");
            string searchIngredient = Console.ReadLine();

            foreach (var salad in salads)
            {
                Ingredient? ingredient = _saladService.SearchIngredient(salad, searchIngredient);
                if (ingredient != null)
                {
                    Console.WriteLine($"{Environment.NewLine}The ingredient {searchIngredient} has salad: {salad.Name}");
                    Console.WriteLine($"{Environment.NewLine}{"Name",-10}{"Type",-20}{"Multiplier",-20}{"Calories",-20} {Environment.NewLine}");
                    Console.WriteLine($"{ingredient.Name,-10}{ingredient.Type,-20}{ingredient.Multiplier,-20}{ingredient.Calories,-20}");
                }
            }
        }
    }
}
