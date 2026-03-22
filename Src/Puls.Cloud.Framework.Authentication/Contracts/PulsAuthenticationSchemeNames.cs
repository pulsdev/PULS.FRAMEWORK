using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Puls.Cloud.Framework.Authentication.Contracts
{
    public class PulsAuthenticationSchemeNames
    {
        public const string Adb2cScheme = JwtBearerDefaults.AuthenticationScheme;
        public const string EntraExternalId = JwtBearerDefaults.AuthenticationScheme;
        public const string CustomJwt = nameof(CustomJwt);
        public const string ApiKey = nameof(ApiKey);
        public const string Internal = nameof(Internal);
        public const string Anonymous = nameof(Anonymous);
    }
}