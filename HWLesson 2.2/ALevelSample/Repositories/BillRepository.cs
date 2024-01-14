using System;
using Entities;
using Models;

namespace Repositories
{
    public class BillRepository
    {
        private readonly BillEntity[] _mockStorage = new BillEntity[100];
        private int _mockStorageCursor = 0;

        public string AddBill(int cost, User user)
        {
            var bill = new BillEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Number = "Bill-" + (_mockStorageCursor + 1).ToString(),
                Cost = cost,
                UserID = user.Id,
                Date = DateTime.Now
            };

            _mockStorage[_mockStorageCursor] = bill;
            _mockStorageCursor++;
            return bill.Id;
        }

        public BillEntity GetBill(string id)
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
