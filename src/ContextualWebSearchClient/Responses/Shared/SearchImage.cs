using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualWebSearchClient.Responses.Shared
{
    public class SearchImage
    {
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Thumbnail { get; set; }
        public int ThumbnailHeight { get; set; }
        public int ThumbnailWidth { get; set; }
        public string Base64Encoding { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public SearchProvider Provider { get; set; }
        public string ImageWebSearchUrl { get; set; }
        public string WebpageUrl { get; set; }
    }
}
