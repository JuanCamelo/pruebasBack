using System.Text.Json.Serialization;

namespace AplicacionDigital.Services.DTOs
{
    public class FiltersDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

    }
}
