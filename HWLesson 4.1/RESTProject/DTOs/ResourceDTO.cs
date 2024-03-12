using Newtonsoft.Json;

namespace  DTOs
{
    public class ResourceDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        [JsonProperty(PropertyName ="pantone_value")]
        public string PantoneValue { get; set; }
    }
}
