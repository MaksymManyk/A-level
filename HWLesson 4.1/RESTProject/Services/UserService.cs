using Config;
using DTOs;
using DTOs.Requests;
using DTOs.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstractions;
 
namespace  Services
{
    public class UserService : IUserService
    {
        private readonly IPublicHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public UserService(IPublicHttpClientService httpClientService, ILogger<UserService> logger, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<MainResponce<ListResponse<List<UserDTO>>>> GetListUsersByPage(int page)
            {
            var result = await _httpClientService.SendAsync<ListResponse<List<UserDTO>>, object>($"{_options.Host}{_options.ListUsers}{page}",HttpMethod.Get);
            if (result.IsSuccess) 
            {
                _logger.LogInformation($"List users from page #{page} is found");
            }

            return result;
            }

        public async Task<MainResponce<BaseResponse<UserDTO>>> GetUserById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDTO>, object>($"{_options.Host}{_options.SingleUser}{id}", HttpMethod.Get );
            if (result.IsSuccess)
            {
                _logger.LogInformation($"User with ID={id} is found");
            }

            return result;
        }

        public async Task<MainResponce<UserCreateResponse>> CreateUser(UserCreateDTO user)
        {
            var result = await _httpClientService.SendAsync<UserCreateResponse, UserRequest>(
                $"{_options.Host}{_options.UserCreate}", HttpMethod.Post, new UserRequest() { Name = user.Name, Job = user.Job });

            if (result.IsSuccess)
            {
                _logger.LogInformation($"User with ID={result.Data.ID} was created");
            }

            return result;
        }

        public async Task<MainResponce<UserUpdateResponse>> UpdateUser(UserCreateDTO user, HttpMethod method)
        {
            var result = await _httpClientService.SendAsync<UserUpdateResponse, UserRequest>(
                $"{_options.Host}{_options.UserUpdate}{user.ID}", method, new UserRequest() { Name = user.Name, Job = user.Job });

            if (result.IsSuccess)
            {
                _logger.LogInformation($"User with Name={result.Data.Name}  updated");
            }

            return result;
        }

        public async Task<MainResponce<BaseResponse<UserDTO>>> DeleteUser (UserCreateDTO user)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDTO>, object>(
                $"{_options.Host}{_options.UserDelete}{user.ID}", HttpMethod.Delete);

            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                _logger.LogInformation($"User with ID={user.ID}  was deleted");
            }

            return result;
        }

        public void PrintUserByID(MainResponce<BaseResponse<UserDTO>> responce, int id)
        {
            if (responce.IsSuccess)
            {
                Console.WriteLine($"{Environment.NewLine}User with ID:{id}{Environment.NewLine}");
                PrintUser(responce.Data.Data);
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}User with ID:{id} not found{Environment.NewLine}");
            }
        }

        public void PrintUser(UserDTO user)
        {
            Console.WriteLine($"ID: {user.ID}, Surname: {user.Surname}, Name: {user.Name}, Email: {user.Email}, Avatar: {user.AvatarUrl} ");
        }

        public void PrintCreateUser(MainResponce<UserCreateResponse> responce, UserCreateDTO user)
        {
            Console.WriteLine($"Create user: {Environment.NewLine}");
            if (responce.IsSuccess)
            {
                Console.WriteLine($"User {user.Name} was create with ID:{responce.Data.ID}, Name:{responce.Data.Name}, Job:{responce.Data.Job}, Date{responce.Data.CreatedAt}");
            }
            else
            {
                Console.WriteLine($"User {user.Name} didn't create");
            }
        }

        public void PrintUpdateUser(MainResponce<UserUpdateResponse> responce, UserCreateDTO user, HttpMethod method)
        {
            Console.WriteLine($"{Environment.NewLine}Updated user method {method}: {user.Name} ");
            if (responce.IsSuccess)
            {
                Console.WriteLine($"User was updated with  Name:{responce.Data.Name}, Job:{responce.Data.Job}, Date{responce.Data.UpdatedAt}");
            }
            else
            {
                Console.WriteLine("User didn't update");
            }
        }

        public void PrintDeleteUser(MainResponce<BaseResponse<UserDTO>> responce, UserCreateDTO user)
        {
            if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                Console.WriteLine($"{Environment.NewLine}User with ID: {user.ID} was deleted ");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}User with ID:{user.ID} didn't deleted");
            }
        }
    }
}