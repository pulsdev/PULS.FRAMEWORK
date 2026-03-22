using Puls.Cloud.Framework.Authentication.Authentication;
using Puls.Cloud.Framework.Authentication.Contracts;
using Puls.Cloud.Framework.Authentication.Contracts.AnonymousAuthentication;
using Puls.Cloud.Framework.Authentication.Contracts.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Puls.Cloud.Framework.Authentication.AuthenticationClient
{
    public static class PulsAuthenticationClientServiceCollectionExtension
    {
        public static void AddPulsAuthenticationClient(this IServiceCollection services, Func<PulsAuthenticationClientConfig> configurationBuilder, List<string> policyNames)
        {
            var authClientConfiguration = configurationBuilder();
            services.AddAuthentication(PulsAuthenticationSchemeNames.Internal)
                .AddScheme<PulsAuthenticationClientOptions, PulsAuthenticationClientHandler>(PulsAuthenticationClientOptions.DefaultScheme,
                    options =>
                    {
                        options.AuthenticationClientConfig = authClientConfiguration;
                    });
            services.AddScoped<IAuthorizationHandler, InternalPolicyRequirementHandler>();

            services.AddAuthentication(PulsAuthenticationSchemeNames.Anonymous)
                .AddScheme<PulsAnonymousAuthenticationOptions, PulsAnonymousAuthenticationHandler>(PulsAnonymousAuthenticationOptions.DefaultScheme, null);

            services.AddAuthorization(opts =>
            {
                foreach (var policyName in policyNames)
                {
                    opts.AddPolicy(policyName, policyBuilder =>
                    {
                        policyBuilder.AddAuthenticationSchemes(PulsAuthenticationSchemeNames.Internal);
                        policyBuilder.AddRequirements(new InternalPolicyRequirement());
                    });
                }
                opts.AddPolicy(PulsPolicyNames.AllowAnonymous, policyBuilder =>
                {
                    policyBuilder.AddAuthenticationSchemes(PulsAnonymousAuthenticationOptions.DefaultScheme);
                    policyBuilder.RequireAuthenticatedUser();
                });
            });
        }
    }
}