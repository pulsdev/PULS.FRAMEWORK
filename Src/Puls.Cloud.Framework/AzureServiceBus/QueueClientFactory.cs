using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using Puls.Cloud.Framework.Infrastructure.AzureServiceBus;

namespace Puls.Cloud.Framework.AzureServiceBus;

internal class QueueClientFactory : IQueueClientFactory
{
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ConcurrentDictionary<string, ServiceBusSender> _cache = new();

    public QueueClientFactory(ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
    }

    public ServiceBusSender CreateSender(string queueName)
    {
        return _cache.GetOrAdd(queueName, _serviceBusClient.CreateSender(queueName));
    }
}