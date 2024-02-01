using Enum;
using Model;

namespace Service.Abstraction
{
    public interface IDeviceService
    {
        public string AddBathroomDevice(string name, int power, PowerSupply powerSupply, string waterProtection);

        public string AddBedroomDevice(string name, int power, PowerSupply powerSupply, int loudness, int brightness);

        public string AddKitchenDevice(string name, int power, PowerSupply powerSupply, double productivity);

        public ElectricDevice GetDevice(string id);

        public List<ElectricDevice> GetDevice();

        public void GenerateDevices();

        public void PrintDevices(List<ElectricDevice> devices);

        public void TurnOnDevice(string id);

        public void TurnOffDevice(string id);

        public void PrintLogs();
    }
}
