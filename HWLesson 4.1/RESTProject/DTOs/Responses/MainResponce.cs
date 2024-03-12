using System.Net;

namespace DTOs.Responses
{
    public class MainResponce<T>
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }
     }
}
