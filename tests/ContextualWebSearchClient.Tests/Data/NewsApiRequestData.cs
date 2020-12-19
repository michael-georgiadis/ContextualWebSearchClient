using System;
using System.Collections.Generic;
using ContextualWebSearchClient.Request.Url.Required;
using ContextualWebSearchClient.Request.Url.Optional;
using Xunit;

namespace ContextualWebSearchClient.Tests.Data
{
    public static class NewsApiRequestData
    {
        public static TheoryData<string> SimpleQueryRequest =>
            new TheoryData<string>
            {
                "Donald Trump",
                "Joe Biden"
            };

        public static TheoryData<SearchParameters> RequiredParamatersRequest =>
            new TheoryData<SearchParameters>
            {
                new SearchParameters("Donald Trump")
                {
                    AutoCorrect = false,
                    PageNumber = 5
                }
            };

        public static TheoryData<SearchParameters, NewsOptionalParameters> RequiredAndOptionalParametersRequest =>
            new TheoryData<SearchParameters, NewsOptionalParameters>
            {
                {
                    new SearchParameters("Donald Trump"),
                    new NewsOptionalParameters { SafeSearch = false }
                },
                {
                    new SearchParameters("Joe Biden")
                    {
                        PageSize = 10,
                        AutoCorrect = false
                    },
                    new NewsOptionalParameters
                    {
                        FromPublishedDate = DateTime.Now.AddDays(-5)
                    }
                }
            };
    }
}
