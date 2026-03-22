using System;

namespace Puls.Cloud.Framework.Domain;

public class TypedIdInitializationException : Exception
{
    public TypedIdInitializationException(string message)
        : base(message)
    {
    }
}
