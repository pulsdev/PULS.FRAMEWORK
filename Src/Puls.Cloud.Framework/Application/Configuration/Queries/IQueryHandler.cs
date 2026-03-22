using Puls.Cloud.Framework.Application.Contracts;
using MediatR;

namespace Puls.Cloud.Framework.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
      IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
}
