using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
using System.Web;
using System;

namespace ContextualWebSearchClient
{
    public abstract class AbstractContextualClient : HttpClient
    {
        private const string host = "contextualwebsearch-websearch-v1.p.rapidapi.com";

        private string _apiKey;

        protected JsonSerializerOptions serializationOptions { get; set; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public AbstractContextualClient(string apiKey)
        {
            _apiKey = apiKey;

            DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);
            DefaultRequestHeaders.Add("x-rapidapi-host", host);
        }

        public Uri BuildUri(string type, string controller, string parameters)
        {
            return new Uri($"https://{host}/api/{type}/{controller}?{parameters}");
        }

    }
}
