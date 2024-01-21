using Entities;
using Models;

namespace Repositories
{
    public class GiftAssortmentRepository
    {
        private readonly GiftAssortmentEntity[] _mockStorage = new GiftAssortmentEntity[100];
        private int _mockStorageCursor = 0;

        public string AddGiftAssortment(string Name, string TypeId, SweetsQuantity[] sweetsAssortments, double weight)
        {
            var GiftAssortment = new GiftAssortmentEntity()
            {
                GiftAssortmenId = Guid.NewGuid().ToString(),
                GiftName = Name,
                GiftTypeId = TypeId,
                SweetsAssortments = sweetsAssortments,
                Weight = Math.Round(weight, 2)
            };
            this._mockStorage[this._mockStorageCursor] = GiftAssortment;
            this._mockStorageCursor++;
            return GiftAssortment.GiftAssortmenId;
        }

        public GiftAssortmentEntity GetGiftAssortment(string id)
        {
            foreach (var item in this._mockStorage)
            {
                if (item.GiftAssortmenId == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
