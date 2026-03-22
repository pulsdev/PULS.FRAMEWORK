using Azure.Messaging.ServiceBus;

namespace Puls.Cloud.Framework.ServiceBus;

public interface ITopicClientFactory
{
    ServiceBusSender CreateSender(string topic);
}