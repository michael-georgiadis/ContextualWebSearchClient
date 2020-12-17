using System;
using ContextualWebSearchClient.Responses.Shared;

namespace ContextualWebSearchClient.Responses.NewsAndWebSearch
{
    public class Value
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Keywords { get; set; }
        public bool IsSafe { get; set; }
        public DateTime DatePublished { get; set; }
        public SearchProvider Provider { get; set; }
        public SearchImage Image { get; set; }
    }
}
