using Puls.Cloud.Framework.Application.Contracts;
using MediatR;

namespace Puls.Cloud.Framework.Application.Configuration.Queries;

public interface IPageableQueryHandler<in TQuery, TResult> :
      IRequestHandler<TQuery, PagedDto<TResult>> where TQuery : IQuery<PagedDto<TResult>>
{
}
