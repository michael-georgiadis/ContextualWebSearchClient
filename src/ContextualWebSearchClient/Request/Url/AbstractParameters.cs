using ContextualWebSearchClient.Helpers.Extensions;
using System;
using System.Linq;
using System.Web;

namespace ContextualWebSearchClient.Request.Url
{
    public abstract class AbstractParameters
    {
        public override string ToString() =>
            string.Join("&", GetType()
                .GetProperties()
                .Where(property => property.GetValue(this) != null)
                .Select(property =>
                {
                    var value = property.GetValue(this);

                    //switch (property.GetValue(this).ToString())
                    //{
                    //    case "True":
                    //        value = "true";
                    //        break;
                    //    case "False":
                    //        value = "false";
                    //        break;
                    //    default:
                    //        break;
                    //}

                    return string.Format(
                        "{0}={1}",
                        HttpUtility.UrlEncode(property.Name == "Query"
                            ? "q"
                            : property.Name.ToCamelcase()),
                        Uri.EscapeUriString(value.ToString()));
                }));
    }
}
