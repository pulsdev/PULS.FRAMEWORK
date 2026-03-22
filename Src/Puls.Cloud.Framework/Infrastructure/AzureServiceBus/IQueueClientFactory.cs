using Azure.Messaging.ServiceBus;

namespace Puls.Cloud.Framework.Infrastructure.AzureServiceBus;

public interface IQueueClientFactory
{
    ServiceBusSender CreateSender(string queueName);
}