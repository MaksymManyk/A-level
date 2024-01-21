using Models;
using Repositories;

namespace Services
{
    public class BasketService
    {
        private Basket _basket;

        public BasketService(User user, ToyQuantity[] toys)
        {
            _basket = new Basket()
            {
              User = user,
              Toys = toys
            };
        }

        public int CalcBasket(Basket basket)
        {
            int calc = 9;
            return calc;
        }

        public Basket GetBasket()
        {
            if (_basket == null)
            {
                return null;
            }

            return _basket;
        }
    }
}
