using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContextualWebSearchClient.Core.Helpers.Statics
{
    public static class JsonStatics
    {
        public static JsonSerializerOptions CamelCaseSerializer { get; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}
