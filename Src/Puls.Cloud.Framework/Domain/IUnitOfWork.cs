using System.Threading;
using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Domain;

internal interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
