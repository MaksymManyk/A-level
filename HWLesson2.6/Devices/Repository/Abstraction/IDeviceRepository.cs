using Entity;
using Enum;

namespace  Repository.Abstraction
{
    public interface IDeviceRepository
    {
        public string AddBathroomDevice(string name, int power, PowerSupply powerSupply, string waterProtection);

        public string AddBedroomDevice(string name, int power, PowerSupply powerSupply, int loudness, int brightness);

        public string AddKitchenDevice(string name, int power, PowerSupply powerSupply, double productivity);

        public ElectricDeviceEntity GetDevice(string id);

        public ElectricDeviceEntity[] GetDevices();

        public void TurnOnDevice(string id);

        public void TurnOffDevice(string id);
    }
}
