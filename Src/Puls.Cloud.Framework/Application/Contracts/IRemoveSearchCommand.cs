namespace Puls.Cloud.Framework.Application.Contracts;

public interface IRemoveSearchCommand<out TResult> : ICommand<TResult>
{
    string IndexName { get; }
}