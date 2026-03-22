using System.Security.Claims;
using System.Text.Encodings.Web;
using Puls.Cloud.Framework.Authentication.Contracts.ApiKeyAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Puls.Cloud.Framework.Authentication.Authentication
{
	public class PulsApiKeyAuthenticationHandler : AuthenticationHandler<PulsApiKeyAuthenticationOptions>
	{
		private readonly IApiKeyStore _apiKeyStore;

		public PulsApiKeyAuthenticationHandler(
			IOptionsMonitor<PulsApiKeyAuthenticationOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			IApiKeyStore apiKeyStore) : base(options, logger, encoder)
		{
			_apiKeyStore = apiKeyStore;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			try
			{
				string? apiKey = null;
				if (Request.Headers.TryGetValue(PulsApiKeyAuthenticationOptions.TokenHeaderName, out var headerToken) == true
					&& string.IsNullOrWhiteSpace(headerToken) == false)
				{
					apiKey = headerToken!;
				}
				else
				{
					var errorMessage = $"Missing API key in header: {PulsApiKeyAuthenticationOptions.TokenHeaderName}. Query parameter authentication is disabled for security reasons.";
					Logger.LogError("Api Key Authentication Failed. " + errorMessage);
					return AuthenticateResult.Fail(errorMessage);
				}

				var pulsClaims = await _apiKeyStore.GetClaimsByApiKeyAsync(apiKey);
				if (pulsClaims is not { Count: > 0 })
				{
					var errorMessage = "Invalid Api Key";
					Logger.LogError("Api Key Authentication Failed. " + errorMessage);
					return AuthenticateResult.Fail(errorMessage);
				}

				var claims = pulsClaims.Select(x => new Claim(x.Type, x.Value)).ToList();

				var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);

				var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

				return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
			}
			catch (Exception e)
			{
				Logger.LogError(e, "Api Key Authentication Failed.");
				return AuthenticateResult.Fail("Api Key Authentication Failed.");
			}
		}
	}
}