using System;
using Xunit;
using ContextualWebSearchClient;
using System.Threading.Tasks;
using System.Net;
using ContextualWebSearchClient.Tests.Data;
using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Request.Url.Optional;
using FluentAssertions;

namespace ContextualWebSearchClient.Tests
{
    public class NewsApiClientTests : BaseApiClientTest
    {
        private ContextualWebSearchClient _newApiClient;


        public NewsApiClientTests() : base() =>
            _newApiClient = new ContextualWebSearchClient(Config["ContextualApiKey"]);


        [Theory]
        [MemberData(nameof(NewsApiRequestData.SimpleQueryRequest), MemberType = typeof(NewsApiRequestData))]
        public async Task TextTest(string query)
        {
            var response = await _newApiClient.NewsSearch(query);

            response.Status
                .Should()
                .Be(HttpStatusCode.OK);


        }

        [Theory]
        [MemberData(nameof(NewsApiRequestData.RequiredParamatersRequest), MemberType = typeof(NewsApiRequestData))]
        public async Task RequiredTest(SearchParameters searchParamaters)
        {
            var response = await _newApiClient.NewsSearch(searchParamaters);

            response.Status
                .Should()
                .Be(HttpStatusCode.OK);

            response.SearchResults
                .Should()
                .NotBeEmpty()
                .And
                .NotBeNull();
        }

        [Theory]
        [MemberData(nameof(NewsApiRequestData.RequiredAndOptionalParametersRequest), MemberType = typeof(NewsApiRequestData))]
        public async Task RequiredOptionalTest(SearchParameters searchParameters, NewsOptionalParameters optionalParameters)
        {
            var response2 = await _newApiClient.NewsSearch("Donald Trump");

            var response = await _newApiClient.NewsSearch(searchParameters, optionalParameters);

            response.Status
                .Should()
                .Be(HttpStatusCode.OK);

            response.SearchResults
                .Should()
                .NotBeEmpty()
                .And
                .NotBeNull();
        }


    }
}