
namespace  DTOs.Responses
{
    public class UserCreateResponse : UserCreateDTO
    {
        public string ID { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
