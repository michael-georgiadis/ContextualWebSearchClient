using System;
using ContextualWebSearchClient.Core.Request;

namespace ContextualWebSearchClient.Request.Url.Required
{
    public class NonSearchParameters : AbstractParameters
    {
        public string Text { get; set; }

        public NonSearchParameters(string text) => Text = text;
    }
}
