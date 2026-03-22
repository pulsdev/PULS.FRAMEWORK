using Puls.Cloud.Framework.Authentication.Contracts.Configurations;
using Microsoft.AspNetCore.Authentication;

namespace Puls.Cloud.Framework.Authentication.Contracts
{
	public class PulsAuthenticationClientOptions : AuthenticationSchemeOptions
	{
		public const string DefaultScheme = PulsAuthenticationSchemeNames.Internal;
		public const string TokenHeaderName = "Authorization";
		public const string ApiManagementSubscriptionKeyHeaderName = "Ocp-Apim-Subscription-Key";
		public PulsAuthenticationClientConfig AuthenticationClientConfig { get; set; } = null!;
	}
}