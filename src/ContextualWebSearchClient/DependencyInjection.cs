using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using ContextualWebSearchClient.Interfaces;

namespace ContextualWebSearchClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContextectualNewsApiClient(this IServiceCollection services, string apiKey)
        {
            var newsApiClient = new ContextualWebSearchClient(apiKey);

            return services.AddSingleton<IContextualNewsApiClient>(sp =>
                new ContextualWebSearchClient(apiKey));
        }
    }
}
