using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContextualWebSearchClient.Responses.Shared;
using System.Net;

namespace ContextualWebSearchClient.Responses.ImageSearch
{
    public class ImageSearchResponse
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonPropertyName("_type")]
        public string Type { get; set; }
        public int TotalCount { get; set; }

        [JsonPropertyName("value")]
        public List<SearchImage> Images { get; set; }
    }
}
