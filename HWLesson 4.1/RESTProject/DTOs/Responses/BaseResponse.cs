namespace DTOs.Responses
{
    public class BaseResponse<T>
        where T : class
    {
        public T Data { get; set; }

        public SupportDTO Support { get; set; }
    }
}
