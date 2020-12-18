using System;
using ContextualWebSearchClient.Core.Request;

namespace ContextualWebSearchClient.Request.Url.Optional
{
    public class NewsOptionalParameters : AbstractParameters
    {
        public bool? SafeSearch { get; set; }
        public bool? WithThumbnails { get; set; }
        public DateTime? FromPublishedDate { get; set; }
        public DateTime? ToPublishedDate { get; set; }
    }
}
