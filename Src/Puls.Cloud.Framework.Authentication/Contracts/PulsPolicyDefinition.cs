using Microsoft.AspNetCore.Authorization;

namespace Puls.Cloud.Framework.Authentication.Contracts
{
	public class PulsPolicyDefinition
	{
		public string PolicyName { get; set; } = null!;
		public string AuthenticationSchemeName { get; set; } = null!;
		public Action<AuthorizationPolicyBuilder>? RequirementBuilder { get; set; }
	}
}