using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.Domain
{
    class DomainEventsShouldBeImmutable : ArchRule
    {
        internal override void Check()
        {
            var result =
                DomainEvents
                .Should()
                .BeInitOnly();

            AssertArchTestResult(result);
        }
    }
}
