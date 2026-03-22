using Puls.Cloud.Framework.Authentication.Authentication;
using Puls.Cloud.Framework.Authentication.Contracts.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPulsAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPulsAuthentication(
            null,
            null,
            () =>
            {
                var entraExternalIdConfig = new EntraExternalIdConfig();
                configuration.GetSection(EntraExternalIdConfig.Key).Bind(entraExternalIdConfig);
                return entraExternalIdConfig;
            },
            null,//serviceCollection => serviceCollection.AddTransient<IApiKeyStore, ApiKeyStore>(),
            new JwtBearerEvents
            {
                OnAuthenticationFailed = AuthenticationFailed
            });

        return services;
    }

    private static Task AuthenticationFailed(AuthenticationFailedContext context)
    {
        var logger = context.HttpContext.RequestServices.GetService<ILogger>();

        if (logger != null)
        {
            if (context?.Exception?.GetType() == typeof(SecurityTokenExpiredException))
            {
                logger.LogError("Authentication Failed, Token expired");
                return Task.CompletedTask;
            }

            logger.LogError("Authentication Failed");
            logger.LogError(context?.Exception?.ToString());
            logger.LogError(context?.Result?.ToString());
        }

        return Task.CompletedTask;
    }
}