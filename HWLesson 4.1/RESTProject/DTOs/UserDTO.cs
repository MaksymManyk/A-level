using Newtonsoft.Json;

namespace DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }

        public string Email { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string AvatarUrl { get; set; }
    }
}
