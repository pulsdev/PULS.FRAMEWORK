using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventShouldBeImmutable : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .Should()
                .BeInitOnly();

            AssertArchTestResult(result);
        }
    }
}
