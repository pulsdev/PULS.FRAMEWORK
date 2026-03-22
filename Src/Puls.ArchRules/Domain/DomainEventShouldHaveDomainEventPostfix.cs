using Puls.Cloud.Framework.Domain;
using NetArchTest.Rules;

namespace Puls.ArchRules.Domain
{
    internal class DomainEventShouldHaveDomainEventPostfix : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.DomainAssembly)
                .That()
                .Inherit(typeof(DomainEventBase))
                .Or()
                .Inherit(typeof(IDomainEvent))
                .Should().HaveNameEndingWith("DomainEvent")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}