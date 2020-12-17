using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContextualWebSearchClient.Responses.Shared;

namespace ContextualWebSearchClient.Responses.ImageSearch
{
    public class ImageSearchResponse
    {
        [JsonPropertyName("_type")]
        public string Type { get; set; }
        public int TotalCount { get; set; }
        public List<SearchImage> Value { get; set; }
    }
}
