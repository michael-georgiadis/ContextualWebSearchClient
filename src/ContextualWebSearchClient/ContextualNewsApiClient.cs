using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System;

using ContextualWebSearchClient.Request.Url.Optional;
using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Responses.ImageSearch;
using ContextualWebSearchClient.Responses.NewsAndWebSearch;
using ContextualWebSearchClient.Helpers.Extensions;

namespace ContextualWebSearchClient
{
    public class ContextualNewsApiClient : AbstractContextualClient
    {
        public ContextualNewsApiClient(string apiKey)
            : base(apiKey) { }

        public async Task<NewsAndWebSearchResponse> GetNews(SearchParameters searchParamaters, NewsOptionalParameters optionalParameters)
        {
            return await Get($"{searchParamaters}{optionalParameters}");
        }

        public void GetNews(SearchParameters searchParameters)
        {

        }

        public async Task<NewsAndWebSearchResponse> GetNews(string query)
        {
            var parameters = new SearchParameters(query);

            return await Get(parameters.ToString());
        }

        private async Task<NewsAndWebSearchResponse> Get(string parameters)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = BuildUri("search", "NewsSearchAPI", parameters)
            };

            using (var response = await SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var newsResponse = JsonSerializer.Deserialize<NewsAndWebSearchResponse>(responseBody, serializationOptions);

                newsResponse.Status = response.StatusCode;

                return newsResponse;
            }
        }
    }
}
