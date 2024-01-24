using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options; 
using Service;
using Service.Abstraction;

namespace ExceptionLog
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json")
            .Build();

            var serviceCollection = new ServiceCollection()
            .AddTransient<IActionService, ActionService>()
            .AddSingleton<ILogService, LogService>()
            .AddTransient<App>();

            serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logging"));
            //string logFolderPath = configuration["Logging:LogFilePath"];

            var provider = serviceCollection.BuildServiceProvider(); 

            var app = provider.GetService<App>();
            app!.Run();
        }
    }
}
