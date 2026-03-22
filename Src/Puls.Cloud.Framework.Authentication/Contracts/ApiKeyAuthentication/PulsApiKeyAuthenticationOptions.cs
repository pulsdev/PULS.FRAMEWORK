using Microsoft.AspNetCore.Authentication;

namespace Puls.Cloud.Framework.Authentication.Contracts.ApiKeyAuthentication;

public class PulsApiKeyAuthenticationOptions : AuthenticationSchemeOptions
{
	public const string DefaultScheme = PulsAuthenticationSchemeNames.ApiKey;
	public const string TokenHeaderName = "x-api-key";
	public const string TokenQueryParameterName = "api-key";
}