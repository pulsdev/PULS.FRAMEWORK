using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using Puls.Cloud.Framework.ServiceBus;

namespace Puls.Cloud.Framework.AzureServiceBus;

internal class TopicClientFactory : ITopicClientFactory
{
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ConcurrentDictionary<string, ServiceBusSender> _clients = new();

    public TopicClientFactory(ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
    }

    public ServiceBusSender CreateSender(string topic) =>
        _clients.GetOrAdd(topic, t => _serviceBusClient.CreateSender(topic));
}