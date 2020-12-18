using System;
using Xunit;
using ContextualWebSearchClient;
using System.Threading.Tasks;
using System.Net;
using ContextualWebSearchClient.Tests.Data.NewsApi;
using ContextualWebSearchClient.Request.Url.Required;

namespace ContextualWebSearchClient.Tests
{
    public class NewsApiClientTests : BaseApiClientTest
    {
        private ContextualNewsApiClient _newApiClient;


        public NewsApiClientTests() : base() =>

            _newApiClient = new ContextualNewsApiClient(Config["ContextualApiKey"]);


        [Theory]
        [MemberData(nameof(NewsApiRequestData.SimpleQueryRequest), MemberType = typeof(NewsApiRequestData))]
        public async Task JustTextQuery(string query)
        {
            var response = await _newApiClient.GetNews(query);
        }

        [Theory]
        [MemberData(nameof(NewsApiRequestData.RequiredParamatersRequest), MemberType = typeof(NewsApiRequestData))]
        public async Task RequiredParamatersQueryRequest(SearchParameters searchParamaters)
        {
            var response = await _newApiClient.GetNews(searchParamaters);
        }


    }
}