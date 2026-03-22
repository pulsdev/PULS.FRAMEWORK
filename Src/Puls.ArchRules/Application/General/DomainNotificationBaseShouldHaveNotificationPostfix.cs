using Puls.Cloud.Framework.Application.Events;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.General
{
    internal class DomainNotificationBaseShouldHaveNotificationPostfix : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .Inherit(typeof(DomainNotificationBase<>))
                .Should()
                .HaveNameEndingWith("Notification")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}