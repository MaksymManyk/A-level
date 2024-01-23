using Model;

namespace Service.Adstraction
{
    public interface ISaladService
    {
        public string AddSalad(string name, List<Ingredient> ingredient, decimal weight);

        public Model.Salad GetSalad (string id);

        public void PrintSalad(Model.Salad salad);
    }
}
