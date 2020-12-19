using ContextualWebSearchClient.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContextualWebSearchClient.Core.Request
{
    public abstract class AbstractParameters
    {
        public override string ToString() =>
              string.Join("&", GetType()
                .GetProperties()
                .Where(property => property.GetValue(this) is not null)
                .Select(property => string.Format(
                        "{0}={1}",
                        HttpUtility.UrlEncode(property.Name == "Query"
                            ? "q"
                            : property.Name.ToCamelcase()),
                        Uri.EscapeUriString(property.GetValue(this).ToString())))
                  );
    }
}
