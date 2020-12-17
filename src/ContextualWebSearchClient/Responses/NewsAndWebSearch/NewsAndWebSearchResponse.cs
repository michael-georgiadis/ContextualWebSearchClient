using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ContextualWebSearchClient.Responses.NewsAndWebSearch
{
    public class NewsAndWebSearchResponse
    {
        [JsonPropertyName("_type")]
        public string Type { get; set; }

        [JsonPropertyName("didUMean")]
        public string DidYouMean { get; set; }

        public int TotalCount { get; set; }

        public List<Value> Value { get; set; }
    }
}
