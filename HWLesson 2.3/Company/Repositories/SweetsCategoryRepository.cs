using Entities;

namespace Repositories
{
    public class SweetsCategoryRepository
    {
        private readonly SweetsCategoryEntity[] _mockStorage = new SweetsCategoryEntity[100];
        private int _mockStorageCursor = 0;

        public string AddSweetsCategory(string categoryName)
        {
            var type = new SweetsCategoryEntity()
            {
                CategoryID = Guid.NewGuid().ToString(),
                Category = categoryName
            };
            this._mockStorage[this._mockStorageCursor] = type;
            this._mockStorageCursor++;
            return type.CategoryID;
        }

        public SweetsCategoryEntity GetSweetsCategory(string id)
        {
            foreach (var item in this._mockStorage)
            {
                if (item.CategoryID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
