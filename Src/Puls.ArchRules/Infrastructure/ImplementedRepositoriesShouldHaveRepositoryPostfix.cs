using Puls.Cloud.Framework.DirectOperations.Repositories;
using NetArchTest.Rules;

namespace Puls.ArchRules.Infrastructure
{
    internal class ImplementedRepositoriesShouldHaveRepositoryPostfix : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.InfrastructureAssembly)
                .That()
                .ImplementInterface(typeof(ICosmosRepository<,>))
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}