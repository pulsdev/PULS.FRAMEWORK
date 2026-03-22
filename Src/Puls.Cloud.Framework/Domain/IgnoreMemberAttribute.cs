using System;

namespace Puls.Cloud.Framework.Domain;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class IgnoreMemberAttribute : Attribute
{
}
