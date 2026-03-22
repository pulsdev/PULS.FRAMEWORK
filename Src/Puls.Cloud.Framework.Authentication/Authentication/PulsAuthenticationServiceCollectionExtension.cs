using System.Text;
using Puls.Cloud.Framework.Authentication.Contracts;
using Puls.Cloud.Framework.Authentication.Contracts.AnonymousAuthentication;
using Puls.Cloud.Framework.Authentication.Contracts.ApiKeyAuthentication;
using Puls.Cloud.Framework.Authentication.Contracts.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Puls.Cloud.Framework.Authentication.Authentication
{
    public static class PulsAuthenticationServiceCollectionExtension
    {
        public static void AddPulsAuthentication(
            this IServiceCollection services,
            Func<B2CAuthenticationConfig>? b2CConfigurationBuilder,
            Func<PulsCustomJwtConfig>? pulsCustomJwtConfigBuilder,
            Func<EntraExternalIdConfig>? entraExternalIdConfigBuilder,
            Action<IServiceCollection>? apiKeyStoreRegistrant,
            JwtBearerEvents? customJwtEvents = null)
        {
            B2CAuthenticationConfig? b2CConfiguration = null;
            if (b2CConfigurationBuilder != null)
            {
                b2CConfiguration = b2CConfigurationBuilder();
            }
            PulsCustomJwtConfig? pulsCustomJwtConfig = null;
            if (pulsCustomJwtConfigBuilder != null)
            {
                pulsCustomJwtConfig = pulsCustomJwtConfigBuilder();
            }

            EntraExternalIdConfig? entraExternalIdConfig = null;
            if (entraExternalIdConfigBuilder != null)
            {
                entraExternalIdConfig = entraExternalIdConfigBuilder();
            }

            if (b2CConfiguration != null)
            {
                if (b2CConfiguration.UseFakeAdb2c)
                {
                    var encryptionKey = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00").ToByteArray();
                    services.AddAuthentication(x =>
                        {
                            x.DefaultAuthenticateScheme = PulsAuthenticationSchemeNames.Adb2cScheme;
                            x.DefaultChallengeScheme = PulsAuthenticationSchemeNames.Adb2cScheme;
                        })
                        .AddJwtBearer(x =>
                        {
                            x.RequireHttpsMetadata = false;
                            x.SaveToken = true;
                            x.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(encryptionKey),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                            if (customJwtEvents != null)
                            {
                                x.Events = customJwtEvents;
                            }
                        });
                    services.AddSingleton<IFakeJwtTokenGenerator, FakeJwtTokenGenerator>();
                }
                else
                {
                    services.AddAuthentication(PulsAuthenticationSchemeNames.Adb2cScheme)
                        .AddJwtBearer(PulsAuthenticationSchemeNames.Adb2cScheme, options =>
                        {
                            options.Authority = $"https://{b2CConfiguration.TenantName}.b2clogin.com/tfp/{b2CConfiguration.DomainName}/{b2CConfiguration.DefaultPolicy}";
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateAudience = true,
                                ValidateIssuer = true,
                                ValidAudiences = b2CConfiguration.Audiences.Split(","),
                                ValidIssuer = $"https://{b2CConfiguration.TenantName}.b2clogin.com/{b2CConfiguration.TenantId}/v2.0/",
                            };
                            if (customJwtEvents != null)
                            {
                                options.Events = customJwtEvents;
                            }
                        });
                }
            }

            if (entraExternalIdConfig != null)
            {
                services.AddAuthentication(PulsAuthenticationSchemeNames.EntraExternalId)
                    .AddJwtBearer(PulsAuthenticationSchemeNames.EntraExternalId, options =>
                    {
                        // Entra External ID uses a specific authority format
                        options.Authority = $"https://{entraExternalIdConfig.EntraName}.ciamlogin.com/{entraExternalIdConfig.TenantId}/v2.0";
                        options.MetadataAddress = $"https://{entraExternalIdConfig.EntraName}.ciamlogin.com/{entraExternalIdConfig.TenantId}/v2.0/.well-known/openid-configuration";

                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ClockSkew = TimeSpan.FromMinutes(5),

                            // Entra External ID specific issuer validation
                            ValidIssuer = $"https://{entraExternalIdConfig.EntraName}.ciamlogin.com/{entraExternalIdConfig.TenantId}/v2.0",
                            ValidAudiences = entraExternalIdConfig.Audiences.Split(","),
                            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
                            {
                                // This will force fetching keys from the JWKS endpoint
                                var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                                    $"https://{entraExternalIdConfig.EntraName}.ciamlogin.com/{entraExternalIdConfig.TenantId}/v2.0/.well-known/openid-configuration",
                                    new OpenIdConnectConfigurationRetriever());

                                var config = configManager.GetConfigurationAsync().Result;
                                return config.SigningKeys;
                            },

                            // Name claim mapping for Entra External ID
                            NameClaimType = "name",
                            RoleClaimType = "roles"
                        };

                        if (customJwtEvents != null)
                        {
                            options.Events = customJwtEvents;
                        }
                    });
            }

            if (pulsCustomJwtConfig != null)
            {
                if (pulsCustomJwtConfig.UseFakeJwt)
                {
                    var encryptionKey = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00").ToByteArray();
                    services.AddAuthentication()
                            .AddJwtBearer(PulsAuthenticationSchemeNames.CustomJwt, x =>
                            {
                                x.RequireHttpsMetadata = false;
                                x.SaveToken = true;
                                x.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(encryptionKey),
                                    ValidateIssuer = false,
                                    ValidateAudience = false
                                };
                                if (customJwtEvents != null)
                                {
                                    x.Events = customJwtEvents;
                                }
                            });
                }
                else
                {
                    services.AddAuthentication()
                        .AddJwtBearer(PulsAuthenticationSchemeNames.CustomJwt, options =>
                    {
                        byte[] secretKey = Encoding.UTF8.GetBytes(pulsCustomJwtConfig.SecurityKey);
                        byte[] encryptionKey = Encoding.UTF8.GetBytes(pulsCustomJwtConfig.EncryptionKey);
                        TokenValidationParameters validationParameters = new TokenValidationParameters
                        {
                            ClockSkew = TimeSpan.Zero,
                            RequireSignedTokens = true,

                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                            RequireExpirationTime = true,
                            ValidateLifetime = true,

                            ValidateAudience = true,
                            ValidAudience = pulsCustomJwtConfig.Audience,

                            ValidateIssuer = true,
                            ValidIssuer = pulsCustomJwtConfig.Issuer,

                            TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey)
                        };

                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = validationParameters;
                        if (customJwtEvents != null)
                        {
                            options.Events = customJwtEvents;
                        }
                    });
                }
            }

            if (b2CConfiguration?.UseFakeAdb2c == true || pulsCustomJwtConfig?.UseFakeJwt == true)
            {
                services.AddSingleton<IFakeJwtTokenGenerator, FakeJwtTokenGenerator>();
            }

            if (apiKeyStoreRegistrant != null)
            {
                apiKeyStoreRegistrant(services);
                services.AddAuthentication(PulsAuthenticationSchemeNames.ApiKey)
                    .AddScheme<PulsApiKeyAuthenticationOptions, PulsApiKeyAuthenticationHandler>(PulsApiKeyAuthenticationOptions.DefaultScheme, null);
            }

            services.AddAuthentication(PulsAuthenticationSchemeNames.Anonymous)
                .AddScheme<PulsAnonymousAuthenticationOptions, PulsAnonymousAuthenticationHandler>(PulsAnonymousAuthenticationOptions.DefaultScheme, null);
        }

        public static void AddPulsAuthorization(this IServiceCollection services, List<PulsPolicyDefinition> pulsPolicyDefinitions)
        {
            services.AddAuthorization(opts =>
            {
                foreach (var pulsPolicyDefinition in pulsPolicyDefinitions)
                {
                    opts.AddPolicy(pulsPolicyDefinition.PolicyName, policyBuilder =>
                    {
                        policyBuilder.AddAuthenticationSchemes(pulsPolicyDefinition.AuthenticationSchemeName);
                        pulsPolicyDefinition.RequirementBuilder?.Invoke(policyBuilder);
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