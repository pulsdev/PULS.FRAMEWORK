using MediatR;

namespace Puls.Cloud.Framework.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}

//public interface IDownloadableQuery<out TResult> : IQuery<TResult>
//{
//    SearchQuery<TResult> SearchQuery { get; }
//}