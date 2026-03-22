using System;

namespace Puls.Cloud.Framework.DirectOperations.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ContainerNameAttribute : Attribute
    {
        public string ContainerName { get; set; } = null!;

        public ContainerNameAttribute(string containerName)
        {
            ContainerName = containerName;
        }
    }
}