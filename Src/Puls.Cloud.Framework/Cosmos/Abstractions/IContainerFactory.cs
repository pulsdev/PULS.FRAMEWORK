using Microsoft.Azure.Cosmos;

namespace Puls.Cloud.Framework.Cosmos.Abstractions;

public interface IContainerFactory
{
    Container Get(string containerName);
}
