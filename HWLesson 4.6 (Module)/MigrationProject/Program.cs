using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CRUDModuleProject;
using Data;
using Services.Abstractions;
using Microsoft.Extensions.Logging;
using Services;
using Repositories.Abstractions;
using Repositories;

void ConfigureService (ServiceCollection serviceCollection , IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<AppDbContext>(opts => opts.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<AppDbContext>, DbContextWrapper<AppDbContext>>();

    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ICategoryRepository , CategoryRepository>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ILocationRepository , LocationRepository>()
        .AddTransient<ILocationService, LocationService>()
        .AddTransient<IBreedRepository , BreedRepository>()
        .AddTransient<IBreedService , BreedService>()
        .AddTransient<IPetRepository, PetRepository>()
        .AddTransient<IPetService, PetService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

var serviceCollection = new ServiceCollection ();
ConfigureService (serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();
var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<AppDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();