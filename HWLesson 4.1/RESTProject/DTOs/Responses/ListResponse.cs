
namespace DTOs.Responses
{
    public class ListResponse<T> : PageDTO
        where T : class
    {
        public T Data { get; set; }

        public SupportDTO Support { get; set; }
    }
}
