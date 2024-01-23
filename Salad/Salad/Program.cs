using Repository;
using Salads;
using Service;
using Microsoft.Extensions.DependencyInjection; 
using Service.Adstraction;
using Repository.Abstraction;

namespace Salad
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IIngredientService, IngredientService>();
            serviceCollection.AddTransient<ISaladService, SaladService>();
            serviceCollection.AddTransient<IIngredientRepository, IngredientRepository>();
            serviceCollection.AddTransient<ISaladRepository, SaladRepository>();

            var app = new App(new SaladService(new SaladRepository()));
            app.Start();
        }
    }
}
