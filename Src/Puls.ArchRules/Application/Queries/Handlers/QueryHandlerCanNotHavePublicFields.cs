using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Puls.ArchRules.Application.Queries.Handlers
{
    class QueryHandlerCanNotHavePublicFields : ArchRule
    {
        internal override void Check()
        {
            var types = QueryHandlersTypes;

            const BindingFlags bindingFlags = BindingFlags.DeclaredOnly |
                                              BindingFlags.Public |
                                              BindingFlags.Instance;

            var failingTypes = new List<Type>();
            foreach (var type in types)
            {
                if (type.GetFields(bindingFlags).Any())
                {
                    failingTypes.Add(type);
                }
            }

            AssertFailingTypes(failingTypes);
        }
    }
}
