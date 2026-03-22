using Puls.ArchRules.Utilities;
using System.Reflection;

namespace Puls.ArchRules.Domain
{
    class DomainEventShouldHaveConstructorWithParametersForItsState : ArchRule
    {
        internal override void Check()
        {
            var result = DomainEvents
                .Should()
                .HaveAConstructorMatchesWithFieldsAndPropsNames(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            AssertArchTestResult(result);
        }
    }
}
