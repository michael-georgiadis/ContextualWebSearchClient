using ContextualWebSearchClient.Helpers.Extensions;
using System.Linq;
using System.Web;

namespace ContextualWebSearchClient.Parameters.Url
{
    public abstract class AbstractParameters
    {
        public override string ToString() =>
            string.Join("&", GetType()
                .GetProperties()
                .Where(property => property.GetValue(this) != null)
                .Select(property => string.Format(
                        "{0}={1}",
                        HttpUtility.UrlEncode(property.Name.ToCamelcase()),
                        HttpUtility.UrlEncode(property.GetValue(this).ToString())
                        )));
    }
}
