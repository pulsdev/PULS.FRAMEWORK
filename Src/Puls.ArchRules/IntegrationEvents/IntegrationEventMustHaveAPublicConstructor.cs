using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventMustHaveAPublicConstructor : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .Should()
                .HaveAPublicConstructor();

            AssertArchTestResult(result);
        }
    }
}
