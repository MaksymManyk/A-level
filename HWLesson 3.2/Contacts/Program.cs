using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Abstractions;
using Services;
using Services.Abstractions;

namespace Contacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void CongigureServices(ServiceCollection serviceCollection)
            {
                 serviceCollection.AddTransient<IContactListService, ContactListService>()
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
