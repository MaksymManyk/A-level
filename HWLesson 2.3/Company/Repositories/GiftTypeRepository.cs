using Entities;

namespace Repositories
{
    public class GiftTypeRepository
    {
        private readonly GiftTypeEntity[] _mockStorage = new GiftTypeEntity[100];
        private int _mockStorageCursor = 0;

        public string AddGiftType(string name)
        {
            var type = new GiftTypeEntity()
            {
                GiftTypeId = Guid.NewGuid().ToString(),
                GiftTypeName = name
            };
            this._mockStorage[this._mockStorageCursor] = type;
            this._mockStorageCursor++;
            return type.GiftTypeId;
        }

        public GiftTypeEntity GetGiftType(string id)
        {
            foreach (var item in this._mockStorage)
            {
                if (item.GiftTypeId == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
