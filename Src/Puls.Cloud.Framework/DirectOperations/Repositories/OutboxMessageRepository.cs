using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Outbox;
using Puls.Cloud.Framework.Common.Constants;
using Puls.Cloud.Framework.Cosmos.Abstractions;
using Microsoft.Azure.Cosmos;

namespace Puls.Cloud.Framework.DirectOperations.Repositories
{
    public class OutboxMessageRepository : IOutboxMessageRepository
    {
        private readonly Container _outboxContainer;

        public OutboxMessageRepository(IContainerFactory containerFactory)
        {
            _outboxContainer = containerFactory.Get(ServiceDatabaseContainersBase.OutboxMessages);
        }

        public async Task<OutboxMessage> CreateAsync(OutboxMessage message)
        {
            var response = await _outboxContainer.CreateItemAsync(message, new PartitionKey(message.PartitionKey));
            return response.Resource;
        }

        public async Task DeleteAsync(string id, string partitionKey)
        {
            await _outboxContainer.DeleteItemAsync<OutboxMessage>(id, new PartitionKey(partitionKey));
        }

        public async Task<OutboxMessage> GetByIdAsync(string id, string partitionKey)
        {
            try
            {
                var response = await _outboxContainer.ReadItemAsync<OutboxMessage>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<OutboxMessage> UpdateAsync(OutboxMessage message)
        {
            var response = await _outboxContainer.ReplaceItemAsync(message, message.Id.ToString(), new PartitionKey(message.Id.ToString()));
            return response.Resource;
        }
    }
}