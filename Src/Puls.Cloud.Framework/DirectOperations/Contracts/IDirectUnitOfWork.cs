using System.Threading;
using System.Threading.Tasks;

namespace Puls.Cloud.Framework.DirectOperations.Contracts;

public interface IDirectUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}