using Entity;
using Enum;
using Model;
using Repository.Abstraction;
using Service.Abstraction;

namespace  Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILoggerService _loggerService;

        public DeviceService(IDeviceRepository deviceRepository, ILoggerService loggerService)
        {
            this._deviceRepository = deviceRepository;
            this._loggerService = loggerService;
        }

        public string AddBathroomDevice(string name, int power, PowerSupply powerSupply, string waterProtection)
        {
            try
            {
                var id = _deviceRepository.AddBathroomDevice(name, power, powerSupply, waterProtection);
                _loggerService.Log(LogType.Info, $"Create device {name} with Id={id}");
                return id;
            }
            catch (Exception ex)
            {
                _loggerService.Log(LogType.Error, $"Don't create device {name}: {ex.Message}");
                return null;
            }
        }

        public string AddBedroomDevice(string name, int power, PowerSupply powerSupply, int loudness, int brightness)
        {
            try
            {
                var id = _deviceRepository.AddBedroomDevice(name, power, powerSupply, loudness, brightness);
                _loggerService.Log(LogType.Info, $"Create device {name} with Id={id}");
                return id;
            }
            catch (Exception ex)
            {
                _loggerService.Log(LogType.Error, $"Don't create device {name}: {ex.Message}");
                return null;
            }
        }

        public string AddKitchenDevice(string name, int power, PowerSupply powerSupply, double productivity)
        {
            try
            {
            var id = _deviceRepository.AddKitchenDevice(name, power, powerSupply, productivity);
            _loggerService.Log(LogType.Info, $"Create device {name} with Id={id}");
            return id;
            }
            catch (Exception ex)
            {
                _loggerService.Log(LogType.Error, $"Don't create device {name}: {ex.Message}");
                return null;
            }
        }

        public ElectricDevice GetDevice(string id)
        {
            var electricDevice = _deviceRepository.GetDevice(id);

            if (electricDevice == null)
            {
                _loggerService.Log(LogType.Warning, $"Not founded device with Id = {id}");
                return null;
            }
            else
            {
                return new ElectricDevice()
                {
                    ID = electricDevice.ID,
                    Name = electricDevice.Name,
                    Type = electricDevice.Type,
                    Group = electricDevice.Group,
                    Power = electricDevice.Power,
                    PowerSupply = electricDevice.PowerSupply,
                    TurnON = electricDevice.TurnON,
                };
            }
        }

        public List<ElectricDevice> GetDevice()
        {
            List<ElectricDevice> devicesList = new List<ElectricDevice>();
            var devices = _deviceRepository.GetDevices();
            foreach (var device in devices)
            {
                if (device == null)
                {
                    return devicesList;
                }

                if (device is BathRoomDeviceEntity)
                {
                    var bathRoomDevice = (BathRoomDeviceEntity)device;

                    devicesList.Add(new BathRoomDevice()
                    {
                        ID = bathRoomDevice.ID,
                        Name = bathRoomDevice.Name,
                        Type = bathRoomDevice.Type,
                        Group = bathRoomDevice.Group,
                        Power = bathRoomDevice.Power,
                        PowerSupply = bathRoomDevice.PowerSupply,
                        WaterProtection = bathRoomDevice.WaterProtection,
                        TurnON = bathRoomDevice.TurnON,
                        DateTurnON = bathRoomDevice.DateTurnON,
                        DateTurnOff = bathRoomDevice.DateTurnOff,
                    });
                }
                else if (device is BedRoomDeviceEntity)
                {
                    var bedRoomDevice = (BedRoomDeviceEntity)device;

                    devicesList.Add(new BedRoomDevice()
                    {
                        ID = bedRoomDevice.ID,
                        Name = bedRoomDevice.Name,
                        Type = bedRoomDevice.Type,
                        Group = bedRoomDevice.Group,
                        Power = bedRoomDevice.Power,
                        PowerSupply = bedRoomDevice.PowerSupply,
                        Brightness = bedRoomDevice.Brightness,
                        Loudness = bedRoomDevice.Loudness,
                        TurnON = bedRoomDevice.TurnON,
                        DateTurnON = bedRoomDevice.DateTurnON,
                        DateTurnOff = bedRoomDevice.DateTurnOff,
                    });
                }
                else if (device is KitchenDeviceEntity)
                {
                    var kitchenDevice = (KitchenDeviceEntity)device;

                    devicesList.Add(new KitchenDevice()
                    {
                        ID = kitchenDevice.ID,
                        Name = kitchenDevice.Name,
                        Type = kitchenDevice.Type,
                        Group = kitchenDevice.Group,
                        Power = kitchenDevice.Power,
                        PowerSupply = kitchenDevice.PowerSupply,
                        Productivity = kitchenDevice.Productivity,
                        TurnON = kitchenDevice.TurnON,
                        DateTurnON = kitchenDevice.DateTurnON,
                        DateTurnOff = kitchenDevice.DateTurnOff,
                    });
                }
            }

            return devicesList;
        }

        public void GenerateDevices()
        {
            this.AddBathroomDevice("Electric towel dryer", 1200, PowerSupply.Net220V, "IP56");
            this.AddBathroomDevice("Washing machine", 1500, PowerSupply.Net220V, "IP56");
            this.AddBedroomDevice("TV", 500, PowerSupply.Net220V, 65, 500);
            this.AddKitchenDevice("Electric kettle", 2000, PowerSupply.Net220V, 5.5);
            this.AddBathroomDevice("Hair dryer", 1000, PowerSupply.Net220V, "IP22");
            this.AddBathroomDevice("Electric shaver", 600, PowerSupply.RestoreBattery, "IP55");
            this.AddBedroomDevice("NoteBook", 200, PowerSupply.RestoreBattery, 30, 300);
            this.AddKitchenDevice("Refrigerator", 2500, PowerSupply.Net360V, 0);
            this.AddKitchenDevice("Toaster", 1500, PowerSupply.Net220V, 2.4);
            this.AddBedroomDevice("Desk lamp", 100, PowerSupply.Battery, 0, 1000);
            this.AddKitchenDevice("Electric stove", 3000, PowerSupply.Net360V, 3.0);
        }

        public void PrintDevices(List<ElectricDevice> devices)
        {
            devices.Sort((x, y) => x.Type.CompareTo(y.Type));
            Console.WriteLine($"{Environment.NewLine}{"Name",-25}{"Type",-20}{"Power, Watt\\hour",-20}{"PowerSupply",-20}{"TurnON",-20}{"Consumption, Wt",-20}{Environment.NewLine}");
            foreach (ElectricDevice device in devices)
            {
                device.PrintDevices();
            }
        }

        public void TurnOnDevice(string id)
        {
            try
            {
                _deviceRepository.TurnOnDevice(id);
                _loggerService.Log(LogType.Info, $"Turn ON device with Id = {id}");
            }
            catch (Exception e)
            {
                _loggerService.Log(LogType.Warning, $"Don't turn On device with Id = {id}: {e.Message}");
            }
        }

        public void TurnOffDevice(string id)
        {
            try
            {
                _deviceRepository.TurnOffDevice(id);
                _loggerService.Log(LogType.Info, $"Turn OFF device with Id = {id}");
            }
            catch (Exception e)
            {
                _loggerService.Log(LogType.Warning, $"Don't turn OFF device with Id = {id}: {e.Message}");
            }
        }

        public void PrintLogs()
        {
            _loggerService.PrintLogs();
        }
    }
}
