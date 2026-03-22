namespace Puls.Cloud.Framework.Authentication.Contracts.ApiKeyAuthentication
{
	public interface IApiKeyStore
	{
		public Task<List<PulsClaimItem>> GetClaimsByApiKeyAsync(string apiKey);
	}
}