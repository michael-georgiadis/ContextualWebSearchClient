using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Net;
using ContextualWebSearchClient.Core.Response;

namespace ContextualWebSearchClient.Responses.NewsAndWebSearch
{
    public class NewsAndWebSearchResponse : BaseResponse
    {

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
