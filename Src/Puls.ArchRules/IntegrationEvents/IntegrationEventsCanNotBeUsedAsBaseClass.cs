using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.IntegrationEvents
{
    class IntegrationEventsCanNotBeUsedAsBaseClass : ArchRule
    {
        internal override void Check()
        {
            var result = IntegrationEvents
                .ShouldNot()
                .UsedAsBaseClass(AllTypes);

            AssertArchTestResult(result);
        }
    }
}
