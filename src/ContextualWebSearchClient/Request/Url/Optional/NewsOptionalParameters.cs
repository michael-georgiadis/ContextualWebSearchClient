using ContextualWebSearchClient.Request.Url;
using System;
using System.Collections.Generic;
using System.Linq;
// using ContextualWebSearchClient.Extensions;
using System.Web;

namespace ContextualWebSearchClient.Request.Url.Optional
{
    public class NewsOptionalParameters : AbstractParameters
    {
        public bool? SafeSearch { get; set; }
        public bool? WithThumbnails { get; set; }
        public DateTime? FromPublishedDate { get; set; }
        public DateTime? ToPublishedDate { get; set; }

        //public override string ToString()
        //{
        //    return string.Join("&", GetType()
        //        .GetProperties()
        //        .Where(property => property.GetValue(this) != null)
        //        .Select(property => string.Format(
        //                "{0}={1}",
        //                HttpUtility.UrlEncode(property.Name.ToCamelcase()),
        //                HttpUtility.UrlEncode(property.GetValue(this).ToString())
        //                )));
        //}
    }
}
