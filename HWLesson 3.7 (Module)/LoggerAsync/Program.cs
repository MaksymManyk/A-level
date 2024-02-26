using Config; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstractions;

namespace LoggerAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void CongigureServices(ServiceCollection serviceCollection, IConfiguration config)
            {
                serviceCollection.AddOptions<LoggerOption>().Bind(config.GetSection("logger"));

                serviceCollection.AddSingleton<ILoggerService, LoggerService>()
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
