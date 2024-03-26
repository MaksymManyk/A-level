using Config;
using DTOs.Responses;
using DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstractions;

namespace Services
{
    public class ResourceService : IResourceService
    {
        private readonly IPublicHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public ResourceService(IPublicHttpClientService httpClientService, ILogger<UserService> logger, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<MainResponce<ListResponse<List<ResourceDTO>>>> GetListResourse()
        {
            var result = await _httpClientService.SendAsync<ListResponse<List<ResourceDTO>>, object>($"{_options.Host}{_options.ListResource}", HttpMethod.Get);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"List resources  is found");
            }

            return result;
        }

        public async Task<MainResponce<BaseResponse<ResourceDTO>>> GetResourceById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDTO>, object>($"{_options.Host}{_options.SingleResource}{id}", HttpMethod.Get);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Resource with ID={id} is found");
            }

            return result;
        }

        public void PrintSingleResource(MainResponce<BaseResponse<ResourceDTO>> responce, int id)
        {
            if (responce.IsSuccess)
            {
                Console.WriteLine($"{Environment.NewLine}Resource with ID:{id} was found{Environment.NewLine}");
                PrintResource(responce.Data.Data);
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}Resource with ID:{id} not found{Environment.NewLine}");
            }
        }

        public void PrintResource(ResourceDTO resource)
        {
            Console.WriteLine($"ID: {resource.ID}, Name: {resource.Name}, Year: {resource.Year}, Color: {resource.Color}, PantoneValue: {resource.PantoneValue} ");
        }
    }
}
