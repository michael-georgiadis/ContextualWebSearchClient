using System;
using System.Threading.Tasks;

using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Request.Url.Optional;
using ContextualWebSearchClient.Responses.NewsAndWebSearch;

namespace ContextualWebSearchClient.Interfaces
{
    public interface IContextualNewsApiClient
    {
        Task<NewsAndWebSearchResponse> GetNews(SearchParameters searchParameters, NewsOptionalParameters optionalParameters);

        Task<NewsAndWebSearchResponse> GetNews(SearchParameters searchParameters);

        Task<NewsAndWebSearchResponse> GetNews(string query);
    }
}
