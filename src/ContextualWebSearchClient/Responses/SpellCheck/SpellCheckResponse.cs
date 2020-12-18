using System.Net;
using System.Text.Json.Serialization;

namespace ContextualWebSearchClient.Responses.SpellCheck
{
    class SpellCheckResponse
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
        public string Response { get; set; }
    }
}
