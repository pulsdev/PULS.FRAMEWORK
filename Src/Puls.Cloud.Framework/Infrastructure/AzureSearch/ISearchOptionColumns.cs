using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch
{
    public interface ISearchOptionColumns<TRequest, out TResult>
        where TRequest : DownloadableQuery<TResult>
        where TResult : DownloadSearchDto
    {
        string[] GetFields();

        string GetFileName();

        string GetFileType();
    }
}