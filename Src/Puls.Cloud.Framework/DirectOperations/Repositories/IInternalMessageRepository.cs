using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.InternalCommands;

namespace Puls.Cloud.Framework.DirectOperations.Repositories;

public interface IInternalMessageRepository
{
    Task<InternalCommandMessage> CreateAsync(InternalCommandMessage message);

    Task<InternalCommandMessage> GetByIdAsync(string id, string partitionKey);

    Task<InternalCommandMessage> UpdateAsync(InternalCommandMessage message);

    Task DeleteAsync(string id, string partitionKey);
}