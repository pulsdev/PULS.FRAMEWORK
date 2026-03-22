namespace Puls.Cloud.Framework.Authentication.Contracts.Configurations
{
    public class PulsAuthenticationClientConfig
    {
        public const string Key = "PulsAuthenticationClientConfig";
        public string InternalAuthenticationUrl { get; set; } = null!;
        public string SubscriptionKey { get; set; } = null!;
    }
}
