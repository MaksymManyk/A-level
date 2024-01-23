using Enum;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace  Service.Adstraction
{
    public interface IIngredientService 
    {
        public string AddIngredient(Ingredient ing);

        public Ingredient GetIngredient(string id);

        public Oil CreateOil(string? ingridientName, decimal ingridientMultiplier);

        public Spice CreateSpice(string? ingridientName, decimal ingridientMultiplier);

        public Vegetable CreateVegetable(string? ingridientName, decimal ingridientMultiplier);
    }
}
