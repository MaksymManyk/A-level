using Entities;
namespace Repositories;

public class SweetsTypeRepository
{
    private readonly SweetsTypeEntity[] _mockStorage = new SweetsTypeEntity[100];
    private int _mockStorageCursor = 0;

    public string AddSweetsType(string typeName, string categoryId)
    {
        var type = new SweetsTypeEntity()
        {
            TypeID = Guid.NewGuid().ToString(),
            TypeName = typeName,
            CategoryID = categoryId,
        };
        this._mockStorage[this._mockStorageCursor] = type;
        this._mockStorageCursor++;
        return type.TypeID;
    }

    public SweetsTypeEntity SweetsType(string id)
    {
        foreach (var item in this._mockStorage)
        {
            if (item.TypeID == id)
            {
                return item;
            }
        }

        return null;
    }
}
