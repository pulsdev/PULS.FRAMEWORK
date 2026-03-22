using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Puls.ArchRules.Application.Queries.Queries
{
    class QueriesShouldNotHaveIdProperty : ArchRule
    {
        internal override void Check()
        {
            var types = Queries.GetTypes();

            var failingTypes = new List<Type>();
            foreach (var type in types)
            {
                var properties = type
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.Name.ToLower() == "id");
                if (properties.Any())
                {
                    failingTypes.Add(type);
                }
            }

            AssertFailingTypes(failingTypes);
        }
    }
}
