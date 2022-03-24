using System.Text.Json.Serialization;

namespace Cuttly.Responses
{
    public class Url
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("shortLink")]
        public string ShortLink { get; set; }

        [JsonPropertyName("fullLink")]
        public string FullLink { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
