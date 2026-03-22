using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventPropertiesShouldBePrimitive : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .Should()
                .HaveOnlySimpleOrDefinedProperties(DomainDefinedTypes);

            AssertArchTestResult(result);
        }
    }
}
