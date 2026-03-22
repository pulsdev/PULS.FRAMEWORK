using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Application.InternalCommands;

public interface IInternalCommandRepository
{
    Task AddAsync(InternalCommandMessage message);
}