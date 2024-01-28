using Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Abstraction;
using Service;
using Service.Abstraction;

namespace Devices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void CongigureServices(ServiceCollection serviceCollection, IConfiguration config)
            {
                serviceCollection.AddOptions<LoggerOption>().Bind(config.GetSection("logger"));

                serviceCollection.AddTransient<IDeviceService, DeviceService>()
                    .AddSingleton<ILoggerService, LoggerService>()
                    .AddTransient<IDeviceRepository, DeviceRepository>()
                    .AddTransient<App>();

            }

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json")
            .Build();

            var serviceCollection = new ServiceCollection();

            CongigureServices(serviceCollection, configuration);

            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            app!.Start();
        }
    }
}
