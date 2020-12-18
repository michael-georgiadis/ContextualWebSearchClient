using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualWebSearchClient.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelcase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str[1..];
            }

            return str;
        }

        public static string ToUri(this string str)
        {
            return str.Replace(" ", "%20");
        }
    }
}
