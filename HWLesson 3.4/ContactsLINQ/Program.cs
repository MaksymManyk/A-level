using Repositories;
using Repositories.IRepositories;
using Services;
using Microsoft.Extensions.DependencyInjection;
using Services.IServices;

namespace ContactsLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void CongigureServices(ServiceCollection serviceCollection)
            {
                serviceCollection.AddTransient<IContactService, ContactService>()
                   .AddTransient<IContactRepository, ContactRepository>()
                   .AddTransient<App>();
            }

            var serviceCollection = new ServiceCollection();

            CongigureServices(serviceCollection);

            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            app!.Start();
        }
    }
}
