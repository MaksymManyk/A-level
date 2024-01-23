using Extension;
using Model;
using Repository;
using Service.Adstraction;

namespace Service
{
    public class SaladService : ISaladService
    {
        private readonly SaladRepository _saladRepository;

        public SaladService (SaladRepository saladRepository)
        {
            this._saladRepository = saladRepository;
        }

        public string  AddSalad(string name, List<Ingredient> ingredient, decimal weight)
        {
           var id = _saladRepository.AddSalad(name, ingredient, weight);
           return id;
        }

        public Model.Salad GetSalad(string id)
        {
            var salad = _saladRepository.GetSalad(id);
            if (salad == null)
            {
                return null;
            }

            return new Model.Salad()
            {
                ID = salad.ID,
                Name = salad.Name,
                Weight = salad.Weight,
                Ingredient = salad.Ingredient
            };
        }

        public void PrintSalad (Model.Salad salad) 
        {
            salad.Ingredient.Sort();
            Console.WriteLine($"{Environment.NewLine}Name of salad: {salad.Name}.  Weight:{salad.Weight} gr. Calories:{salad.CalculateCalories()} ccal.");
            Console.WriteLine($"{Environment.NewLine}{"Name",-10}{"Type",-20}{"Multiplier",-20}{"Calories",-20} {Environment.NewLine}");

            foreach (var ing in salad.Ingredient)
            {
                Console.WriteLine($"{ing.Name,-10}{ing.Type,-20}{ing.Multiplier,-20}{ing.Calories,-20}");
            }
        }

        public Ingredient? SearchIngredient (Model.Salad salad, string searchIngredient)
        {
            foreach (var ing in salad.Ingredient)
            {
                if (ing.Name.ToLower() == searchIngredient.ToLower())
                {
                    return ing;
                }
            }

            return null;
        }
    }
}
