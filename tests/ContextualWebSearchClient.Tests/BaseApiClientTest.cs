using Microsoft.Extensions.Configuration;

namespace ContextualWebSearchClient.Tests
{
    public abstract class BaseApiClientTest
    {
        public IConfiguration Config { get; init; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .Build();
    }
}
