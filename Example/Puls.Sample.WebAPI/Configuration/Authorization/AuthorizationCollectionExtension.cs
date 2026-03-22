using Puls.Cloud.Framework.Authentication.Contracts;
using Puls.Cloud.Framework.Authentication.Contracts.AnonymousAuthentication;
using Microsoft.AspNetCore.Authorization;

public static class AuthorizationCollectionExtension
{
    public static IServiceCollection AddPulsAuthorization(this IServiceCollection services)
    {
        //services.AddScoped<IAuthorizationHandler, PlatformPermissionsRequirementHandler>();
        //services.AddScoped<IAuthorizationHandler, B2BPermissionsRequirementHandler>();
        services.AddScoped<IAuthorizationHandler, InternalAuthenticationRequirementHandler>();

        services.AddAuthorization(opts =>
        {
            opts.AddPolicy(PulsPolicyNames.InternalService, policyBuilder =>
            {
                policyBuilder.AddAuthenticationSchemes(PulsAnonymousAuthenticationOptions.DefaultScheme);
                policyBuilder.AddRequirements(new InternalAuthenticationRequirement());
            });

            opts.AddPolicy(PulsPolicyNames.EntraExternalIdOnly, policyBuilder =>
            {
                policyBuilder.AddAuthenticationSchemes(PulsAuthenticationSchemeNames.EntraExternalId);
                policyBuilder.RequireAuthenticatedUser();
            });
        });

        return services;
    }
}