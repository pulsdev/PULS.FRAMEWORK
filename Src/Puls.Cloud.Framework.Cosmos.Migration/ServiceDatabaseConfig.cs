namespace Puls.Cloud.Framework.Cosmos.Migration
{
    public class ServiceDatabaseConfig
    {
        public const string ServiceDatabase = nameof(ServiceDatabaseConfig);

        public string AccountEndpoint { get; set; }

        public string PrimaryKey { get; set; }

        public string DatabaseName { get; set; }
    }
}