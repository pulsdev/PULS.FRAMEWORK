namespace Puls.Cloud.Framework.MicrosoftGraph
{
    public interface IGraphParameterResolver
    {
        string Issuer { get; }
        string ExtensionClientId { get; }
    }
}