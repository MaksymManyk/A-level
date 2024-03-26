using System.Text;
using Newtonsoft.Json;
using Services.Abstractions;
using DTOs.Responses;

namespace Services
{
    public class PublicHttpClientService : IPublicHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PublicHttpClientService (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<MainResponce<TResponce>> SendAsync<TResponce, TRequest>(string url, HttpMethod method, TRequest content = null)
            where TRequest : class
        {
            var client = _clientFactory.CreateClient();
            var httpMessage = new HttpRequestMessage();
            httpMessage.Method = method;
            httpMessage.RequestUri = new Uri(url);
            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            var result = await client.SendAsync(httpMessage);
            var resultContent = await result.Content.ReadAsStringAsync();            
            var responce = JsonConvert.DeserializeObject<TResponce>(resultContent);
            return new MainResponce<TResponce> { StatusCode = result.StatusCode, IsSuccess = result.IsSuccessStatusCode ,Data = responce! };
        }
    }
}
