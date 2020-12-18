using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using ContextualWebSearchClient.Core;
using ContextualWebSearchClient.Interfaces;
using ContextualWebSearchClient.Core.Helpers.Statics;
using ContextualWebSearchClient.Request.Url.Optional;
using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Responses.NewsAndWebSearch;

namespace ContextualWebSearchClient
{
    public class ContextualNewsApiClient : IContextualNewsApiClient
    {
        private ContextualHttpClient _baseContextualClient;

        /// <summary>
        /// Constructor for the standalone API Client
        /// </summary>
        /// <param name="apiKey">The API Key</param>
        public ContextualNewsApiClient(string apiKey) =>
            _baseContextualClient = new ContextualHttpClient(apiKey);

        /// <summary>
        /// This constructor is used for when all the API clients must be used. So, because 
        /// we don't want to create a new pointer with the same data for every single API 
        /// Client, the clients will share one.
        /// </summary>
        /// <param name="baseContextualHttpClient">The shared HttpClient</param>
        public ContextualNewsApiClient(ContextualHttpClient baseContextualHttpClient) =>
            _baseContextualClient = baseContextualHttpClient;


        public async Task<NewsAndWebSearchResponse> GetNews(SearchParameters searchParamaters,
            NewsOptionalParameters optionalParameters) =>
            await Get($"{searchParamaters}{optionalParameters}");


        public async Task<NewsAndWebSearchResponse> GetNews(SearchParameters searchParameters) =>
            await Get(searchParameters.ToString());


        public async Task<NewsAndWebSearchResponse> GetNews(string query)
        {
            var parameters = new SearchParameters(query);

            return await Get(parameters.ToString());
        }

        /// <summary>
        /// Creates the Request URI for the ContextualWebSearchApi and sends it.
        /// Will throw an Exception if unsucessful.
        /// </summary>
        /// <param name="parameters">The URI encoded parameters for the query</param>
        /// <returns>Object of Class NewsAndWebSearchResponse</returns>
        private async Task<NewsAndWebSearchResponse> Get(string parameters)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _baseContextualClient.BuildUri("search", "NewsSearchAPI", parameters)
            };

            using (var response = await _baseContextualClient.SendAsync(request))
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var newsResponse = JsonSerializer.Deserialize<NewsAndWebSearchResponse>(responseBody,
                    JsonStatics.CamelCaseSerializer);

                newsResponse.Status = response.StatusCode;

                return newsResponse;
            }
        }
    }
}
