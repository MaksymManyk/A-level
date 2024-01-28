 using Model; 
using Service.Abstraction; 

namespace Devices
{
    public class App
    {
        private readonly IDeviceService _deviceService;

        public App(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public void Start()
        {
            _deviceService.GenerateDevices();

            List<ElectricDevice> devices = _deviceService.GetDevice();

            Console.WriteLine("You have next devices in appartment:");

            _deviceService.PrintDevices(devices);

            TurnOnDevice(devices);

            devices = _deviceService.GetDevice();

            _deviceService.PrintDevices(devices);

            this.TurnOffDevice(devices);

            devices = _deviceService.GetDevice();

            _deviceService.PrintDevices(devices);

            this.SearchDeviceByPower(devices);

            Console.WriteLine($"{Environment.NewLine}Do you want to watch logs?");

            if (Console.ReadLine().ToString().ToUpper() == "Y")
            {
                Console.WriteLine($"{Environment.NewLine}Logs:{Environment.NewLine}");
                _deviceService.PrintLogs();
            }
        }

        private void TurnOnDevice(List<ElectricDevice> devices)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}What device do you want to turn ON ?");
                string? unswer = Console.ReadLine().ToString();

                ElectricDevice? elDevice = devices.FirstOrDefault(p => p.Name == unswer);

                if (elDevice != null)
                {
                    _deviceService.TurnOnDevice(elDevice.ID);
                    Console.WriteLine($"{Environment.NewLine}You Turn On:");
                    elDevice.PrintDevice();
                }

                Console.WriteLine($"{Environment.NewLine}Do you want turn On any devices next ?: Y/N");

            } while (Console.ReadLine().ToString().ToUpper() == "Y");
        }

        private void TurnOffDevice(List<ElectricDevice> devices)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}What device do you want to turn OFF ?");
                string? unswer = Console.ReadLine().ToString();
                ElectricDevice? elDevice = devices.FirstOrDefault(p => p.Name == unswer);

                if (elDevice != null)
                {
                    _deviceService.TurnOffDevice(elDevice.ID);
                    Console.WriteLine($"{Environment.NewLine}You Turn OFF:");
                    elDevice.PrintDevice();
                }

                Console.WriteLine($"{Environment.NewLine}Do you want turn Off any devices next ?: Y/N");
            } while (Console.ReadLine().ToString().ToUpper() == "Y");
        }

        private void SearchDeviceByPower(List<ElectricDevice> devices)
        {
            Console.WriteLine($"{Environment.NewLine}Up to which power device do you want to find??");
            int powerTo;
            if (int.TryParse(Console.ReadLine(), out powerTo))
            {
                Console.WriteLine($"{Environment.NewLine}Next device has Power less than {powerTo}:{Environment.NewLine}");
                foreach (var device in devices)
                {
                    if (device.Power <= powerTo)
                    {
                        device.PrintDevice();
                    }
                }
            }
        }
    }
}
