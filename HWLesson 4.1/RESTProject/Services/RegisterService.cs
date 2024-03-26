using Config;
using DTOs.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using DTOs.Requests;

namespace Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IPublicHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public RegisterService(IPublicHttpClientService httpClientService, ILogger<UserService> logger, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<MainResponce<RegisterResponce>> CreateLogin(RegisterRequest login)
        {
            var result = await _httpClientService.SendAsync<RegisterResponce, RegisterRequest>($"{_options.Host}{_options.Register}", HttpMethod.Post,new RegisterRequest {  Email = login.Email, Password = login.Password  });
            if (result.IsSuccess)
            {
                _logger.LogInformation($"User {login.Email} was registered");
            }

            return result;
        }

        public async Task<MainResponce<RegisterResponce>> Login(RegisterRequest login)
        {
            var result = await _httpClientService.SendAsync<RegisterResponce, RegisterRequest>($"{_options.Host}{_options.Login}", HttpMethod.Post, login);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"User {login.Email} is login");
            }

            return result;
        }

        public void PrintLogin(MainResponce<RegisterResponce> responce, RegisterRequest user)
        {
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Login  {user.Email} is successfull, with token {responce.Data.Token}");
            }
            else
            {
                Console.WriteLine($"Login {user.Email}  is unsuccessful. {responce.Data.Error}");
            }
        }

        public void PrintCreateLogin(MainResponce<RegisterResponce> responce, RegisterRequest user)
        {
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Login {user.Email} was created with ID:{responce.Data.ID}, Token:{responce.Data.Token}");
            }
            else
            {
                Console.WriteLine($"Login {user.Email} didn't created. {responce.Data.Error}");
            }
        }

    }
}
