using DTOs.Responses;

namespace Services.Abstractions
{
    public interface IPublicHttpClientService
    {
        Task<MainResponce<TResponce>> SendAsync<TResponce, TRequest>(string url, HttpMethod method, TRequest content = null)
            where TRequest : class;
    }
}
