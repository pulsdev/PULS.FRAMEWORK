using NetArchTest.Rules;

namespace Puls.ArchRules.Infrastructure.Audit
{
    internal class AuditConfigurationsShouldHaveAuditConfigurationPostfix : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.InfrastructureAssembly)
                .That()
                .ImplementInterface(typeof(IAuditConfiguration<>))
                .Should()
                .HaveNameEndingWith("AuditConfiguration")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}