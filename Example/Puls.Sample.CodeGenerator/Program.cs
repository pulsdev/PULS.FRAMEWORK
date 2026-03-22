using System.Reflection;
using Puls.CodeGenerator;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.DirectOperations;
using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.CodeGenerator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var defaultColor = Setup();

            var applicationBuilders = await Generator.GenerateApplicationBuildersAsync(
                typeof(Query<>),
                typeof(IQuery<>),
                typeof(Command<>),
                typeof(Command),
                typeof(DirectCommand),
                typeof(DirectCommand<>)).ConfigureAwait(false);
            var domainBuilders = await Generator.GenerateDomainBuildersAsync().ConfigureAwait(false);

            Report(defaultColor, applicationBuilders, domainBuilders);
        }

        private static void Report(
            ConsoleColor defaultColor,
            IEnumerable<string> applicationBuilders,
            IEnumerable<string> domainBuilders)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("The following files has been updated:");
            Console.WriteLine(string.Join(Environment.NewLine, domainBuilders
                .Union(applicationBuilders)
                .Select(x => Path.GetFileName(x))));
            Console.ForegroundColor = defaultColor;
        }

        private static ConsoleColor Setup()
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;

            Generator.AggregateType = typeof(CosmosEntity);
            Generator.ApplicationAssembly = Assembly.Load("Puls.Sample.Application");
            Generator.DomainAssembly = Assembly.Load("Puls.Sample.Domain");
            Generator.EntityType = typeof(Entity);
            Generator.ValueObjectType = typeof(ValueObject);
            Generator.StronglyTypedId = typeof(TypedId);
            Generator.TestHelperPath = "Puls.Sample.TestHelpers";
            return defaultColor;
        }
    }
}