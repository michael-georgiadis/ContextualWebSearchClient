using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
using System.Web;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace ContextualWebSearchClient
{

    public class ContextualHttpClient : HttpClient
    {
        private const string host = "contextualwebsearch-websearch-v1.p.rapidapi.com";

        private string _apiKey;

        public JsonSerializerOptions serializationOptions { get; init; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ContextualHttpClient(string apiKey)
        {
            _apiKey = apiKey;

            DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);
            DefaultRequestHeaders.Add("x-rapidapi-host", host);
        }

        public Uri BuildUri(string type, string controller, string parameters)
        {
            return new Uri($"https://{host}/api/{type}/{controller}?{parameters}");
        }

        public override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using (var response = Send(request, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return response;
            }
        }

        public async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using (var response = await SendAsync(request, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return response;
            }
        }

    }
}
