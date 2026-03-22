namespace Puls.Cloud.Framework.Authentication.Contracts.Configurations
{
    public class EntraExternalIdConfig
    {
        public const string Key = nameof(EntraExternalIdConfig);

        public string? DomainName { get; set; }

        public string TenantId { get; set; } = null!;

        public string EntraName { get; set; } = null!;

        public string Audiences { get; set; } = null!;
    }
}