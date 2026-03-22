using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Puls.Cloud.Framework.Application.Configuration.Commands;
using Puls.Cloud.Framework.Infrastructure.EventBus;

namespace Puls.ArchRules.Application.Notifications
{
    internal class NotificationHandlerOnlyCanHaveDependencyOnSchedulerAndEventBus : ArchRule
    {
        internal override void Check()
        {
            var types = NotificationHandlersTypes;

            var domainInterfaces = new List<Type>()
            {
                typeof(ICommandsScheduler),
                typeof(IEventBus)
            };

            const BindingFlags bindingFlags = BindingFlags.DeclaredOnly |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Public |
                                              BindingFlags.Instance;

            var failingTypes = new List<Type>();
            foreach (var type in types)
            {
                if (!type.GetFields(bindingFlags)
                    .All(x => domainInterfaces.Contains(x.FieldType) ||
                        (x.FieldType.IsGenericType && x.FieldType.GetGenericTypeDefinition() == typeof(IEventBus))))
                {
                    failingTypes.Add(type);
                }
            }

            AssertFailingTypes(failingTypes);
        }
    }
}