using Models;
using Repositories;

namespace Services
{
    public class ToyService
    {
        private readonly ToyRepository _toyRepository;
        public ToyService(ToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public int AddToy(int id, string type, string color, int price)
        {
            var idToy = _toyRepository.AddToy(id, type, color, price);
            return idToy;
        }

        public Toy GetToy(int id)
        {
            var toy = _toyRepository.GetToy(id);

            if (toy == null)
            {
                return null;
            }

            return toy;
        }
    }
}
