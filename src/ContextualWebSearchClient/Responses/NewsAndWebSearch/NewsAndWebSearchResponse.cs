using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Net;

namespace ContextualWebSearchClient.Responses.NewsAndWebSearch
{
    public class NewsAndWebSearchResponse
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonInclude]
        [JsonPropertyName("_type")]
        public string Type { get; set; }

        [JsonPropertyName("didUMean")]
        public string DidYouMean { get; set; }

        public int TotalCount { get; set; }

        public List<string> RelatedSearch { get; set; }

        [JsonInclude]
        [JsonPropertyName("value")]
        public List<Value> SearchResults { get; set; }
    }
}
