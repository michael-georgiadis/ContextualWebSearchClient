namespace ContextualWebSearchClient.Core.Helpers.Extensions
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
