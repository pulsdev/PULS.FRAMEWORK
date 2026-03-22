using Puls.ArchRules.Utilities;
using System.Reflection;

namespace Puls.ArchRules.Domain.ValueObjectRules
{
    class ValueObjects_should_have_a_constructor_matched_with_properties : ArchRule
    {
        internal override void Check()
        {
            var result = ValueObjects
               .Should()
               .HaveAConstructorMatchesWithFieldsAndPropsNames(
                   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            AssertArchTestResult(result);
        }
    }
}
