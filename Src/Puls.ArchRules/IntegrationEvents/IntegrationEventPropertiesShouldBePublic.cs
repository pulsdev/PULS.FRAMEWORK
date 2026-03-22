using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventPropertiesShouldBePublic : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .Should()
                .HaveOnlyPublicProperties();

            AssertArchTestResult(result);
        }
    }
}
