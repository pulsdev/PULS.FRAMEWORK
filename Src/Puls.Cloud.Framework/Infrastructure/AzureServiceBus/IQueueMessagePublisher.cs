using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Infrastructure.AzureServiceBus;

public interface IQueueMessagePublisher
{
    Task PublishAsync(string queue, string sessionId, string raw);

    Task PublishAsync<T>(string queue, string sessionId, T obj);
}