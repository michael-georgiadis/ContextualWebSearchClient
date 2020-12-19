using System;
using System.Threading.Tasks;

using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Request.Url.Optional;
using ContextualWebSearchClient.Responses.NewsAndWebSearch;

namespace ContextualWebSearchClient.Interfaces
{
    public interface IContextualNewsApiClient
    {
        Task<NewsAndWebSearchResponse> NewsSearch(SearchParameters searchParameters, NewsOptionalParameters optionalParameters);

        Task<NewsAndWebSearchResponse> NewsSearch(SearchParameters searchParameters);

        Task<NewsAndWebSearchResponse> NewsSearch(string query);
    }
}
