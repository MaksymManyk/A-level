using Entity;
using Model;
using Repository.Abstraction;

namespace Repository
{
    public class SaladRepository : ISaladRepository
    {
        private readonly SaladEntity[] _mockStorage = new SaladEntity[100];
        private int _mockStorageCursor = 0;

        public string AddSalad(string name, List<Ingredient> ingredient, decimal weight)
        {
            var salad = new SaladEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Ingredient = ingredient,
                Weight = weight
            };

            this._mockStorage[this._mockStorageCursor] = salad;
            this._mockStorageCursor++;
            return salad.ID;
        }

        public SaladEntity GetSalad(string id)
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
