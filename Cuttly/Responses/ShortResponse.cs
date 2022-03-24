using System.Text.Json.Serialization;

namespace Cuttly.Responses
{
    public class ShortResponse
    {
        [JsonPropertyName("url")]
        public Url Url { get; set; }
    }
}
