using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualWebSearchClient.Request.Url.Required
{
    public class NonSearchParameters : AbstractParameters
    {
        public string Text { get; set; }

        public NonSearchParameters(string text) => Text = text;
    }
}
