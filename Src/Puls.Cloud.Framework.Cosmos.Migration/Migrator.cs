namespace Puls.Cloud.Framework.Cosmos.Migration;

public abstract class Migrator
{
    public abstract Task MigrateAsync();
    public abstract string Version { get; }
    public abstract int Order { get; }
    public abstract string Description { get; }
}
