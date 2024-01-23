using Entity;
using Model;
 

namespace Repository.Abstraction
{
    public interface ISaladRepository
    {
        public string AddSalad(string name, List<Ingredient> ingredient, decimal weight);

        public SaladEntity GetSalad(string id);
    }
}
