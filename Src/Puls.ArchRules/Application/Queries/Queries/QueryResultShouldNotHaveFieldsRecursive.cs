using System;
using System.Collections.Generic;

namespace Puls.ArchRules.Application.Queries.Queries
{
    class QueryResultShouldNotHaveFieldsRecursive : ArchRule
    {
        internal override void Check()
        {
            var types = QueryResults;

            var failingTypes = new List<Type>();
            foreach (var type in types)
            {
                if (ContainsFields(type))
                {
                    failingTypes.Add(type);
                }
            }

            AssertFailingTypes(failingTypes);
        }
    }
}
