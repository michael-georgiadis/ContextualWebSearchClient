using System;
using System.Collections.Generic;
using ContextualWebSearchClient.Request.Url.Required;
using Xunit;

namespace ContextualWebSearchClient.Tests.Data.NewsApi
{
    public class NewsApiRequestData
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
    }
}
