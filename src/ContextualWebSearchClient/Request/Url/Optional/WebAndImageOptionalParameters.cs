using ContextualWebSearchClient.Core.Request;

namespace ContextualWebSearchClient.Request.Url.Optional
{
    public class WebAndImageOptionalParameters : AbstractParameters
    {
        public bool SafeSearch { get; set; }
    }
}
