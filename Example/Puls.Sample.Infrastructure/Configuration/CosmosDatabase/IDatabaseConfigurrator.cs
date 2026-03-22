namespace Puls.Sample.Infrastructure.Configuration.CosmosDatabase
{
    public interface IDatabaseConfigurrator
    {
        Task ExecuteAsync(CancellationToken cancelationToken);

        Task ExecuteAsync(string databaseName);
    }
}