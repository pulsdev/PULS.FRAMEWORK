using System.Reflection;

namespace Puls.Cloud.Framework.Infrastructure.Configuration;

public interface IApplicationAssemblyResolver
{
    Assembly Resolve();
}