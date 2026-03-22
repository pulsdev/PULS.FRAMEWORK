using System.Threading;
using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Domain;
using MediatR;

namespace Puls.Cloud.Framework.Infrastructure.Processing.CommandPipelines;

internal class CommandUnitOfWorkBehavior<T, TResult> : IPipelineBehavior<T, TResult> where T : ICommand<TResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CommandUnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(T request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var result = await next();
        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}