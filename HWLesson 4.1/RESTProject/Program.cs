using Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstractions;
using Microsoft.Extensions.Logging;
using RESTProject;

void ConfigureService(ServiceCollection service, IConfiguration config)
            {
                service.AddOptions<ApiOption>().Bind(config.GetSection("Api"));
                service
                    .AddHttpClient()
                    .AddTransient<IPublicHttpClientService, PublicHttpClientService>()
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<IResourceService,ResourceService>()
                    .AddTransient<IRegisterService,RegisterService>()
                    .AddTransient<App>();
            }

IConfiguration congiguration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
var services = new ServiceCollection();
ConfigureService(services, congiguration);
var provider = services.BuildServiceProvider();
var app = provider.GetService<App>();
await app!.Start();
