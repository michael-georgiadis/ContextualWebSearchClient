using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using ContextualWebSearchClient.Core;
using ContextualWebSearchClient.Interfaces;
using ContextualWebSearchClient.Core.Helpers.Statics;
using ContextualWebSearchClient.Request.Url.Optional;
using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Responses.NewsAndWebSearch;
using ContextualWebSearchClient.Responses.ImageSearch;
using ContextualWebSearchClient.Core.Response;

namespace ContextualWebSearchClient
{
    public class ContextualWebSearchClient : IContextualNewsApiClient
    {
        private ContextualHttpClient _baseContextualClient;

        /// <summary>
        /// Constructor for the standalone API Client
        /// </summary>
        /// <param name="apiKey">The API Key</param>
        public ContextualWebSearchClient(string apiKey) =>
            _baseContextualClient = new ContextualHttpClient(apiKey);

        /// <summary>
        /// This constructor is used for when all the API clients must be used. So, because 
        /// we don't want to create a new pointer with the same data for every single API 
        /// Client, the clients will share one.
        /// </summary>
        /// <param name="baseContextualHttpClient">The shared HttpClient</param>
        public ContextualWebSearchClient(ContextualHttpClient baseContextualHttpClient) =>
            _baseContextualClient = baseContextualHttpClient;

        #region NewsSearch
        public async Task<NewsAndWebSearchResponse> NewsSearch(SearchParameters searchParameters,
            NewsOptionalParameters optionalParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.News,
                string.Format("{0}&{1}", searchParameters, optionalParameters));

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }


        public async Task<NewsAndWebSearchResponse> NewsSearch(SearchParameters searchParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.News,
                searchParameters.ToString());

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }


        public async Task<NewsAndWebSearchResponse> NewsSearch(string query)
        {
            var parameters = new SearchParameters(query);

            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search, Controllers.News, parameters.ToString());

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }

        #endregion

        #region ImageSearch

        public async Task<ImageSearchResponse> ImageSearch(SearchParameters searchParameters,
            WebAndImageOptionalParameters optionalParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Image,
                string.Format("{0}&{1}", searchParameters, optionalParameters));

            return await GetSearchResponseAsync<ImageSearchResponse>(request);
        }

        public async Task<ImageSearchResponse> ImageSearch(SearchParameters searchParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Image,
                searchParameters.ToString());

            return await GetSearchResponseAsync<ImageSearchResponse>(request);
        }

        public async Task<ImageSearchResponse> ImageSearch(string query)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Image,
                new SearchParameters(query).ToString());

            return await GetSearchResponseAsync<ImageSearchResponse>(request);
        }

        #endregion

        #region WebSearch

        public async Task<NewsAndWebSearchResponse> WebSearch(SearchParameters searchParameters,
            WebAndImageOptionalParameters optionalParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Web,
                string.Format("{0}&{1}", searchParameters, optionalParameters));

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }

        public async Task<NewsAndWebSearchResponse> WebSearch(SearchParameters searchParameters)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Web,
                searchParameters.ToString());

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }

        public async Task<NewsAndWebSearchResponse> WebSearch(string query)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Search,
                Controllers.Web,
                new SearchParameters(query).ToString());

            return await GetSearchResponseAsync<NewsAndWebSearchResponse>(request);
        }

        #endregion

        public async Task<List<string>> AutoComplete(string text)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Spelling,
                Controllers.AutoComplete,
                new NonSearchParameters(text).ToString());

            return await GetAutoCompleteResult(request);
        }

        public async Task<string> SpellCheck(string text)
        {
            var request = _baseContextualClient.BuildRequestMessage(CallTypes.Spelling,
                Controllers.SpellCheck,
                new NonSearchParameters(text).ToString());

            return await GetSpellCheckAsync(request);
        }

        private async Task<TResult> GetSearchResponseAsync<TResult>(HttpRequestMessage request) where TResult : BaseResponse
        {
            var response = await _baseContextualClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<TResult>(responseBody, JsonStatics.CamelCaseSerializer);

            result.Status = response.StatusCode;

            return result;
        }

        private async Task<List<string>> GetAutoCompleteResult(HttpRequestMessage request)
        {
            var response = await _baseContextualClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<string>>(responseBody);
        }

        private async Task<string> GetSpellCheckAsync(HttpRequestMessage request)
        {
            var response = await _baseContextualClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }


    }
}
