using System.Net;
using System.Text.Json.Serialization;

namespace ContextualWebSearchClient.Core.Response
{
    public class BaseResponse
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
    }
}
