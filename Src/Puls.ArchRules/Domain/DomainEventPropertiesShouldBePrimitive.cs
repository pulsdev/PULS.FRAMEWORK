using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.Domain
{
    class DomainEventPropertiesShouldBePrimitive : ArchRule
    {
        internal override void Check()
        {
            var definedTypes = DomainDefinedTypes;
            var result = DomainEvents
                .Should()
                .HaveOnlySimpleOrDefinedProperties(definedTypes);

            AssertArchTestResult(result);
        }
    }
}
