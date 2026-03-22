using Microsoft.Graph;

namespace Puls.Cloud.Framework.MicrosoftGraph
{
    public interface IGraphClientFactory
    {
        GraphServiceClient Get();
    }
}