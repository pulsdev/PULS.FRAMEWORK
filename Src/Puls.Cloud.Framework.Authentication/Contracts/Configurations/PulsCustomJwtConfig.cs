namespace Puls.Cloud.Framework.Authentication.Contracts.Configurations
{
    public class PulsCustomJwtConfig
    {
        public const string Key = nameof(PulsCustomJwtConfig);
        public string SecurityKey { get; set; } = null!;
        public string EncryptionKey { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int IdExpiresInDays { get; set; }
        public int AccessExpiresInHours { get; set; }
        public int AccessExpiresInMinutes { get; set; }
        public int RefreshExpiresInDays { get; set; }
        public bool UseFakeJwt { get; set; }
    }
}
