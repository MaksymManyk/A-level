using Entities;

namespace  Repositories
{
    public class SweetsAssortmentRepository
    {
        private readonly SweetsAssortmentEntity[] _mockStorage = new SweetsAssortmentEntity[100];
        private int _mockStorageCursor = 0;

        public string AddSweetsAssortment(string assortmentName, string typeId, double weight, string color)
        {
            var assortment = new SweetsAssortmentEntity()
            {
                AssortmentID = Guid.NewGuid().ToString(),
                AssortmentName = assortmentName,
                TypeID = typeId,
                Weight = weight,
                Color = color
            };
            this._mockStorage[this._mockStorageCursor] = assortment;
            this._mockStorageCursor++;
            return assortment.AssortmentID;
        }

        public SweetsAssortmentEntity GetSweetsAssortment(string id)
        {
            foreach (var item in this._mockStorage)
            {
                if (item.AssortmentID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
