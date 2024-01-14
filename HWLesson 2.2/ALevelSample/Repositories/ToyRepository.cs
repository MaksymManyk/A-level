using System;
using Models;

namespace Repositories
{
    public class ToyRepository
    {
        private readonly Toy[] _mockStorage = new Toy[100];
        private int _mockStorageCursor = 0;

        public int AddToy(int id, string type, string color, int price)
        {
            var toy = new Toy()
            {
                Id = id,
                Type = type,
                Color = color,
                Price = price
            };

            _mockStorage[_mockStorageCursor] = toy;
            _mockStorageCursor++;
            return toy.Id;
        }

        public Toy GetToy(int id)
        {
            for (int i = 0; i < _mockStorage.Length; i++)
            {
                if (_mockStorage[i].Id == id)
                {
                    return _mockStorage[i];
                }
            }

            return null;
        }
    }
}
