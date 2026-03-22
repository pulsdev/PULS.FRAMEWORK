using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Outbox;

namespace Puls.Cloud.Framework.DirectOperations.Repositories;

public interface IOutboxMessageRepository
{
    Task<OutboxMessage> CreateAsync(OutboxMessage message);

    Task<OutboxMessage> GetByIdAsync(string id, string partitionKey);

    Task<OutboxMessage> UpdateAsync(OutboxMessage message);

    Task DeleteAsync(string id, string partitionKey);
}