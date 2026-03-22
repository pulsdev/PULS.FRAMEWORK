using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventsCanNotHaveIdProperty : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .ShouldNot()
                .HavePropertyWithName("id");

            AssertArchTestResult(result);
        }
    }
}
