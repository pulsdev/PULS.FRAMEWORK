using System.Security.Claims;
using System.Text.Encodings.Web;
using Puls.Cloud.Framework.Authentication.Contracts;
using Puls.Cloud.Framework.Authentication.Contracts.ApiKeyAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Puls.Cloud.Framework.Authentication.AuthenticationClient
{
    public class PulsAuthenticationClientHandler : AuthenticationHandler<PulsAuthenticationClientOptions>
    {
        public PulsAuthenticationClientHandler(
            IOptionsMonitor<PulsAuthenticationClientOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Headers.ContainsKey(PulsAuthenticationClientOptions.TokenHeaderName) == false &&
                Request.Headers.ContainsKey(PulsApiKeyAuthenticationOptions.TokenHeaderName) == false &&
                Request.Query.ContainsKey(PulsApiKeyAuthenticationOptions.TokenQueryParameterName) == false)
            {
                return AuthenticateResult.Fail($"Missing header: {PulsAuthenticationClientOptions.TokenHeaderName} or {PulsApiKeyAuthenticationOptions.TokenHeaderName} or Query parameter: {PulsApiKeyAuthenticationOptions.TokenQueryParameterName} ");
            }

            string? bearerToken = null;
            if (Request.Headers.TryGetValue(PulsAuthenticationClientOptions.TokenHeaderName, out var bToken))
            {
                bearerToken = bToken;
                if (string.IsNullOrWhiteSpace(bearerToken) == true)
                {
                    return AuthenticateResult.Fail($"Missing header value: {PulsAuthenticationClientOptions.TokenHeaderName}");
                }
            }

            string? apiKeyToken = null;
            if (Request.Headers.TryGetValue(PulsApiKeyAuthenticationOptions.TokenHeaderName, out var aToken))
            {
                apiKeyToken = aToken;
            }

            if (string.IsNullOrWhiteSpace(apiKeyToken) == true &&
                Request.Query.TryGetValue(PulsApiKeyAuthenticationOptions.TokenQueryParameterName, out var aqToken))
            {
                apiKeyToken = aqToken;
            }

            var endpoint = Request!.HttpContext!.GetEndpoint();
            var authorizeAttribute = endpoint?.Metadata.GetMetadata<PulsAuthorizeAttribute>();
            if (authorizeAttribute == null)
            {
                return AuthenticateResult.Fail($"Missing endpoint authorize attribute.");
            }

            using var client = new RestClient();

            if (string.IsNullOrWhiteSpace(bearerToken) == false)
            {
                client.AddDefaultHeader(PulsAuthenticationClientOptions.TokenHeaderName, bearerToken);
            }

            if (string.IsNullOrWhiteSpace(apiKeyToken) == false)
            {
                client.AddDefaultHeader(PulsApiKeyAuthenticationOptions.TokenHeaderName, apiKeyToken);
            }

            client.AddDefaultHeader(PulsAuthenticationClientOptions.ApiManagementSubscriptionKeyHeaderName, Options.AuthenticationClientConfig.SubscriptionKey);

            if (Request.Headers.TryGetValue("Origin", out var origin) && !string.IsNullOrEmpty(origin))
            {
                client.AddDefaultHeader("Origin", origin!);
            }

            if (Request.Headers.TryGetValue("tenantId", out var tenantId) && !string.IsNullOrEmpty(tenantId))
            {
                client.AddDefaultHeader("tenantId", tenantId!);
            }

            var restRequest = new RestRequest(Options.AuthenticationClientConfig.InternalAuthenticationUrl, Method.Post);

            restRequest.AddBody(new
            {
                authorizeAttribute.Policy,
                authorizeAttribute.Permission,
            });

            var response = await client.ExecuteAsync(restRequest);
            if (response is not { IsSuccessful: true })
            {
                Logger.LogInformation($"Internal Authentication Failed. {response.StatusCode}");
                return AuthenticateResult.Fail("Internal Authentication Failed.");
            }

            List<Claim>? claims = null;

            if (string.IsNullOrWhiteSpace(response.Content) == false)
            {
                var claimModel = JsonConvert.DeserializeObject<PulsInternalAuthenticationModel>(response.Content);
                if (claimModel?.Claims is { Count: > 0 })
                {
                    claims = claimModel.Claims.Select(x => new Claim(x.Type, x.Value)).ToList();
                    claims.Add(new Claim("IsAuthorized", claimModel.IsAuthorized.ToString()));
                }
            }

            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }
    }
}