namespace Puls.Cloud.Framework.Application.Contracts;

public interface IUpdateSearchCommand<out TResult> : ICommand<TResult>
{
    string IndexName { get; }
}