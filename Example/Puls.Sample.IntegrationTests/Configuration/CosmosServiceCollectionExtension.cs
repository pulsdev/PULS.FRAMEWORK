using Puls.Sample.Infrastructure.Configuration.CosmosDatabase;
using Puls.Cloud.Framework.Cosmos;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Puls.Sample.IntegrationTests.Configuration
{
    internal static class CosmosServiceCollectionExtension
    {
        public static IServiceCollection AddIntegrationTestCosmosDb(this IServiceCollection services, IConfiguration configuration, string databaseName)
        {
            var accountEndpoint = configuration.GetValue<string>("ServiceDatabaseConfig:AccountEndpoint");
            var accountKey = configuration.GetValue<string>("ServiceDatabaseConfig:AccountKey");

            var jsonSerializerSetting = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };

            var cosmosClientOptions = new CosmosClientOptions
            {
                Serializer = new CosmosJsonDotNetSerializer(jsonSerializerSetting)
            };

            services.AddCosmosDb(databaseName, accountEndpoint!, accountKey!, cosmosClientOptions);

            return services;
        }
    }
}