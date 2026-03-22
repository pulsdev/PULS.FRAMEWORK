namespace Puls.Cloud.Framework.Application.Contracts;

public interface ISearchQuery<out TResult> : IQuery<TResult>
{
    string IndexName { get; }
    string Keyword { get; }
}