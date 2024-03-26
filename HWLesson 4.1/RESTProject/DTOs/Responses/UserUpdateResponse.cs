
namespace  DTOs.Responses
{
    public class UserUpdateResponse : UserCreateDTO
    {
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
