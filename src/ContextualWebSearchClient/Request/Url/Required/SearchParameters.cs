using System;
using ContextualWebSearchClient.Core.Request;

namespace ContextualWebSearchClient.Request.Url.Required
{
    public class SearchParameters : AbstractParameters
    {
        public string Query { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value >= 1 && value <= 50)
                    _pageSize = value;
                else
                    throw new ArgumentOutOfRangeException("PageNumber",
                        new Exception("Must be between 1 and 50"));
            }
        }

        public bool AutoCorrect { get; set; } = true;

        public SearchParameters(string query) => Query = query;
    }
}
