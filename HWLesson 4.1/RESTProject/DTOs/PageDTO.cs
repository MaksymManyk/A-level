using Newtonsoft.Json;

namespace DTOs
{
    public class PageDTO
    {
        public int page { get; set; }

        [JsonProperty(PropertyName ="per_page")]
        public int perPage { get; set; }

        [JsonProperty(PropertyName ="total")]
        public int totalUsers { get; set; }

        [JsonProperty(PropertyName="total_Pages")]
        public int totalPages { get; set; }
    }
}
