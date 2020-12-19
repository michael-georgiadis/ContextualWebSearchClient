using ContextualWebSearchClient.Core.Response;
using System.Net;
using System.Text.Json.Serialization;

namespace ContextualWebSearchClient.Responses.SpellCheck
{
    class SpellCheckResponse : BaseResponse
    {
        public string Response { get; set; }
    }
}
