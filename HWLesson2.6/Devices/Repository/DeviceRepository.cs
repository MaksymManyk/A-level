using Entity;
using Enum;
using Repository.Abstraction;

namespace Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ElectricDeviceEntity[] _mockStorage = new ElectricDeviceEntity[100];
        private int _mockStorageCursor = 0;

        public string AddBathroomDevice(string name, int power, PowerSupply powerSupply, string waterProtection)
        {
            var device = new BathRoomDeviceEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Type = ElectricDeviceType.ForBathRoom,
                Group = DeviceGroup.ElectricDevice,
                Power = power,
                PowerSupply = powerSupply,
                WaterProtection = waterProtection,
                TurnON = false,
            };

            this._mockStorage[this._mockStorageCursor] = device;
            this._mockStorageCursor++;
            return device.ID;
        }

        public string AddBedroomDevice(string name, int power, PowerSupply powerSupply, int loudness, int  brightness)
        {
            var device = new BedRoomDeviceEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Type = ElectricDeviceType.ForBedRoom,
                Group = DeviceGroup.ElectricDevice,
                Power = power,
                PowerSupply = powerSupply,
                Loudness = loudness,
                TurnON = false,
                Brightness = brightness,
            };

            this._mockStorage[this._mockStorageCursor] = device;
            this._mockStorageCursor++;
            return device.ID;

        }

        public string AddKitchenDevice(string name, int power, PowerSupply powerSupply, double productivity)
        {
            var device = new KitchenDeviceEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Type = ElectricDeviceType.ForKitchen,
                Group = DeviceGroup.ElectricDevice,
                Power = power,
                PowerSupply = powerSupply,
                Productivity = productivity,
                TurnON = false,
            };

            this._mockStorage[this._mockStorageCursor] = device;
            this._mockStorageCursor++;
            return device.ID;
        }

        public ElectricDeviceEntity GetDevice(string id)
        {
            foreach (var device in this._mockStorage)
            {
                if (device.ID == id)
                {
                    return device;
                }
            }

            return null;
        }

        public ElectricDeviceEntity[] GetDevices()
        {
            return _mockStorage;
        }

        public void TurnOnDevice(string id)
        {
            for (var i = 0; i < this._mockStorage.Length; i++)
            {
                if (_mockStorage[i] != null && _mockStorage[i].ID.Equals(id))
                {
                    _mockStorage[i].TurnON = true;
                    _mockStorage[i].DateTurnON = DateTime.UtcNow;
                    _mockStorage[i].DateTurnOff = null;
                }
            }
        }

        public void TurnOffDevice(string id)
        {
            for (var i = 0; i < this._mockStorage.Length; i++)
            {
                if (_mockStorage[i] != null && _mockStorage[i].ID.Equals(id))
                {
                    _mockStorage[i].TurnON = false;
                    _mockStorage[i].DateTurnOff = DateTime.UtcNow;
                }
            }
        }
    }
}
